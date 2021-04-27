using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipePal.Models;
using RecipePal.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RecipePal.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        readonly IRepository<Recipe> _recipesRepo;
        readonly IRepository<Note> _notesRepo;

        public Recipe Recipe { get; private set; }
        public IEnumerable<Note> Notes { get; private set; }

        public IndexModel(IRepository<Recipe> recipes, IRepository<Note> notes)
        {
            _recipesRepo = recipes;
            _notesRepo = notes;
        }

        public void OnGet(int id)
        {
            Recipe = _recipesRepo.Get(id);
            Notes = _notesRepo.Get().Where(n => n.RecipeId == Recipe.Id);
        }

        public IActionResult OnPostDeleteNote(int id)
        {
            Note deleted = _notesRepo.Delete(id);
            return RedirectToPage(new { id = deleted.RecipeId });
        }
    }
}
