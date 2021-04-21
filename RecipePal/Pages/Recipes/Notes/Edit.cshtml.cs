using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipePal.Models;
using RecipePal.Models.Repositories;

namespace RecipePal.Pages.Recipes.Notes
{
    public class EditModel : PageModel
    {
        public IRepository<Note> NotesRepo { get; private set; }

        public Note Note { get; set; }

        public EditModel(IRepository<Note> notes)
        {
            NotesRepo = notes;
        }

        public void OnGet(int id)
        {
            Note = NotesRepo.Get(id);
        }

        public IActionResult OnPost(Note note)
        {
            Note = NotesRepo.Update(note);
            return RedirectToPage("../Index", new { id = Note.RecipeId });
        }
    }
}
