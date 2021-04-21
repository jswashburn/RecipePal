using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipePal.Models;
using RecipePal.Models.Repositories;

namespace RecipePal.Pages.Recipes.Notes
{
    public class CreateModel : PageModel
    {
        public IRepository<Note> NotesRepo { get; private set; }
        public IRepository<Recipe> RecipesRepo { get; private set; }

        public Note Note { get; set; }
        public Recipe Recipe { get; set; }

        public CreateModel(IRepository<Note> notes, IRepository<Recipe> recipes)
        {
            NotesRepo = notes;
            RecipesRepo = recipes;
        }

        public void OnGet(int recipeId)
        {
            Recipe = RecipesRepo.Get(recipeId);
        }

        public IActionResult OnPost(Note note)
        {
            Note = NotesRepo.Insert(note);
            return RedirectToPage("../Index", new { id = Note.RecipeId });
        }
    }
}
