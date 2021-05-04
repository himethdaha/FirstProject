using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage.Models;

namespace RazorPage.Pages.JournalList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        //BindProperty automatically assumes the Post returns this property
        [BindProperty]
        public Journal journals { get; set; }
        public void OnGet()
        {
        }

        //Handler for Form Submit
        //<IActionResult> - returining to a new page
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.journal.AddAsync(journals);
                await _db.SaveChangesAsync();
                return RedirectToPage("JournalIndex");
            }
            else
            {
                return Page();
            }
        }
    }
}
