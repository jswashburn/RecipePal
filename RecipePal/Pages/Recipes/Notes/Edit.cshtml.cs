using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipePal.Models;
using RecipePal.Models.Repositories;

namespace RecipePal.Pages.Recipes.Notes
{
    public class EditModel : PageModel
    {
        readonly IRepository<Note> _notesRepo;

        public Note Note { get; set; }

        public EditModel(IRepository<Note> notes)
        {
            _notesRepo = notes;
        }

        public void OnGet(int id)
        {
            Note = _notesRepo.Get(id);
        }

        public IActionResult OnPost(Note note)
        {
            Note = _notesRepo.Update(note);
            return RedirectToPage("../Index", new { id = Note.RecipeId });
        }
    }
}
