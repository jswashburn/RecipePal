using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipePal.Models;
using RecipePal.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RecipePal.Pages
{
    public class IndexModel : PageModel
    {
        public IRepository<Cookbook> CookbooksRepo { get; private set; }
        public IRepository<User> UsersRepo { get; set; }

        public List<Cookbook> Cookbooks { get; set; }

        public IndexModel(IRepository<Cookbook> cookbooks, IRepository<User> users)
        {
            CookbooksRepo = cookbooks;
            UsersRepo = users;
        }

        public void OnGet()
        {
            Cookbooks = CookbooksRepo.Get().ToList();
            foreach (Cookbook cookbook in Cookbooks)
                cookbook.User = UsersRepo.Get(cookbook.UserId);
        }
    }
}
