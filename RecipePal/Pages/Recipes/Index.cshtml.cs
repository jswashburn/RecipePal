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
        public IRepository<Recipe> RecipesRepo { get; private set; }
        public IRepository<Note> NotesRepo { get; private set; }

        public Recipe Recipe { get; set; }
        public IEnumerable<Note> Notes { get; set; }

        public IndexModel(IRepository<Recipe> recipes, IRepository<Note> notes)
        {
            RecipesRepo = recipes;
            NotesRepo = notes;
        }

        public void OnGet(int id)
        {
            Recipe = RecipesRepo.Get(id);
            Notes = NotesRepo.Get().Where(n => n.RecipeId == Recipe.Id);
        }

        public IActionResult OnPostDeleteNote(int id)
        {
            Note deleted = NotesRepo.Delete(id);
            return RedirectToPage(new { id = deleted.RecipeId });
        }
    }
}
