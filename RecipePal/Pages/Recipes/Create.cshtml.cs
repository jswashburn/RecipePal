using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipePal.Models;
using RecipePal.Models.Repositories;

namespace RecipePal.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        readonly IRepository<Recipe> _recipesRepo;
        readonly IRepository<Cookbook> _cookbooksRepo;

        public Cookbook Cookbook { get; set; }
        public Recipe Recipe { get; set; }
        
        public CreateModel(IRepository<Recipe> recipes, IRepository<Cookbook> cookbooks)
        {
            _recipesRepo = recipes;
            _cookbooksRepo = cookbooks;
        }

        public void OnGet(int id)
        {
            Cookbook = _cookbooksRepo.Get(id);
        }

        public IActionResult OnPost(Recipe recipe)
        {
            Recipe = _recipesRepo.Insert(recipe);
            return RedirectToPage("../Users/EditCookbook", new { id = Recipe.CookbookId });
        }
    }
}
