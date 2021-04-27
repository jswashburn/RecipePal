using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipePal.Models;
using RecipePal.Models.Repositories;

namespace RecipePal.Pages.Users
{
    public class IndexModel : PageModel
    {
        readonly IRepository<RPUser> _rpUsersRepo;
        
        public RPUser RPUser { get; set; }
        
        public IndexModel(IRepository<RPUser> users)
        {
            _rpUsersRepo = users;
        }
        
        public void OnGet(int id)
        {
            RPUser = _rpUsersRepo.Get(id);
        }
    }
}