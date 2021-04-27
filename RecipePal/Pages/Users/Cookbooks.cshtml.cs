using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipePal.Models;
using RecipePal.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RecipePal.Pages.Users
{
    public class CookbooksModel : PageModel
    {
        readonly IRepository<Cookbook> _cookbooksRepo;
        readonly IRepository<RPUser> _rpUsersRepo;

        public List<Cookbook> UserCookbooks { get; set; }
        public RPUser RPUser { get; set; }

        public CookbooksModel(IRepository<Cookbook> cookbooks, IRepository<RPUser> rpUsers)
        {
            _cookbooksRepo = cookbooks;
            _rpUsersRepo = rpUsers;
        }

        public void OnGet(int userId)
        {
            UserCookbooks = _cookbooksRepo.Get().Where(c => c.UserId == userId).ToList();
            RPUser = _rpUsersRepo.Get(userId);
            foreach (Cookbook cookbook in UserCookbooks)
                cookbook.User = RPUser;
        }

        public IActionResult OnPostDeleteCookbook(int id)
        {
            Cookbook cookbook = _cookbooksRepo.Delete(id);
            return RedirectToPage(new { userId = cookbook.UserId });
        }
    }
}
