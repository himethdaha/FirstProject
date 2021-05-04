using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage.Models;

namespace RazorPage.Pages.JournalList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Journal journals { get; set; }

        public async Task OnGet(int id)
        {
            journals = await _db.journal.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var BookFromDb = await _db.journal.FindAsync(journals.EntryID);
                BookFromDb.EntryName = journals.EntryName;
                BookFromDb.EntryDescription = journals.EntryDescription;
                BookFromDb.EntryDate = journals.EntryDate;

                await _db.SaveChangesAsync();

                return RedirectToPage("JournalIndex");
            }

            else
            {
                return RedirectToPage();
            }
        }
    }
}