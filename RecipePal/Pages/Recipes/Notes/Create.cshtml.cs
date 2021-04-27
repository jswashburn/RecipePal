using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipePal.Models;
using RecipePal.Models.Repositories;

namespace RecipePal.Pages.Recipes.Notes
{
    public class CreateModel : PageModel
    {
        readonly IRepository<Note> _notesRepo;
        readonly IRepository<Recipe> _recipesRepo;

        public Note Note { get; set; }
        public Recipe Recipe { get; set; }

        public CreateModel(IRepository<Note> notes, IRepository<Recipe> recipes)
        {
            _notesRepo = notes;
            _recipesRepo = recipes;
        }

        public void OnGet(int recipeId)
        {
            Recipe = _recipesRepo.Get(recipeId);
        }

        public IActionResult OnPost(Note note)
        {
            Note = _notesRepo.Insert(note);
            return RedirectToPage("../Index", new { id = Note.RecipeId });
        }
    }
}
