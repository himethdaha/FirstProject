using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage.Models;

namespace RazorPage.Pages.JournalList
{
    public class JournalIndexModel : PageModel
    {
        //Object of ApplicationDbContext
        private readonly ApplicationDbContext _db;

        public JournalIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        //Return List of journals
        public IEnumerable<Journal> journals { get; set; }

        //Get list of journals and return it to the IEnumerable property
        public async Task OnGet()
        {
            journals = await _db.journal.ToListAsync();
        }
    }
}
