using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipePal.Models;
using RecipePal.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RecipePal.Pages.Cookbooks
{
    public class IndexModel : PageModel
    {
        public IRepository<Cookbook> CookbooksRepo { get; private set; }
        public IRepository<Recipe> RecipesRepo { get; private set; }


        public Cookbook Cookbook { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; }

        public IndexModel(IRepository<Cookbook> cookbooks, IRepository<Recipe> recipes)
        {
            CookbooksRepo = cookbooks;
            RecipesRepo = recipes;
        }

        public void OnGet(int id)
        {
            Cookbook = CookbooksRepo.Get(id);
            Recipes = RecipesRepo.Get().Where(r => r.CookbookId == Cookbook.Id);
        }
    }
}
