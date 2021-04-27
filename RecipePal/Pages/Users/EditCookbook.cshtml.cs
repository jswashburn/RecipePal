using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipePal.Models;
using RecipePal.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RecipePal.Pages.Users
{
    public class EditCookbookModel : PageModel
    {
        readonly IRepository<Cookbook> _cookbooksRepo;
        readonly IRepository<RPUser> _rpUsersRepo;
        readonly IRepository<Recipe> _recipesRepo;

        public Cookbook Cookbook { get; set; }
        public RPUser RpUser { get; set; }
        public Recipe Recipe { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; }

        public EditCookbookModel(IRepository<Cookbook> cookbooks, IRepository<RPUser> rpUsers,
            IRepository<Recipe> recipes)
        {
            _cookbooksRepo = cookbooks;
            _rpUsersRepo = rpUsers;
            _recipesRepo = recipes;
        }

        public void OnGet(int id)
        {
            Cookbook = _cookbooksRepo.Get(id);
            RpUser = _rpUsersRepo.Get(Cookbook.UserId);
            Recipes = _recipesRepo.Get().Where(r => r.CookbookId == Cookbook.Id);
        }

        public IActionResult OnPost(Cookbook cookbook)
        {
            Cookbook = _cookbooksRepo.Update(cookbook);
            return RedirectToPage("Cookbooks", new { userId = Cookbook.UserId });
        }

        public IActionResult OnPostDeleteRecipe(int id)
        {
            Recipe = _recipesRepo.Delete(id);
            return RedirectToPage(new { id = Recipe.CookbookId });
        }
    }
}
