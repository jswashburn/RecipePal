using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipePal.Models.Repositories;
using RecipePal.Models;
using Microsoft.AspNetCore.Mvc;

namespace RecipePal.Pages.Recipes
{
    public class EditModel : PageModel
    {
        readonly IRepository<Recipe> _recipesRepo;

        public Recipe Recipe { get; set; }

        public EditModel(IRepository<Recipe> recipes)
        {
            _recipesRepo = recipes;
        }

        public void OnGet(int id)
        {
            Recipe = _recipesRepo.Get(id);
        }

        public IActionResult OnPost(Recipe recipe)
        {
            Recipe = _recipesRepo.Update(recipe);
            return RedirectToPage("Users/EditCookbooks", new { id = Recipe.Cookbook.UserId });
        }
    }
}
