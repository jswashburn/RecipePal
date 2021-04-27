using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipePal.Models.Repositories;
using RecipePal.Models;
using Microsoft.AspNetCore.Mvc;

namespace RecipePal.Pages.Cookbooks
{
    public class CreateModel : PageModel
    {
        readonly IRepository<Cookbook> _cookbooksRepo;
        readonly IRepository<RPUser> _rpUsersRepo;

        public Cookbook Cookbook { get; set; }
        public RPUser RPUser { get; set; }

        public CreateModel(IRepository<Cookbook> cookbooks, IRepository<RPUser> rpUsers)
        {
            _cookbooksRepo = cookbooks;
            _rpUsersRepo = rpUsers;
        }

        public void OnGet(int userId)
        {
            RPUser = _rpUsersRepo.Get(userId);
        }

        public IActionResult OnPost(Cookbook cookbook)
        {
            Cookbook = _cookbooksRepo.Insert(cookbook);
            return RedirectToPage("../Users/Cookbooks", new { userId = Cookbook.UserId });
        }
    }
}
