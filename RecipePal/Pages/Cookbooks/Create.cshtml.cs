using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipePal.Data;

namespace RecipePal.Pages.Cookbooks
{
    public class CreateModel : PageModel
    {
        readonly RPDbContext _context;

        public CreateModel(RPDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }
    }
}
