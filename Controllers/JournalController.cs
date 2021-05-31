using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPage.Controllers
{
    [Route("api/Journal")]
    [ApiController]
    public class JournalController : Controller
    {
        private readonly ApplicationDbContext _db;

        public JournalController(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Journal journals { get; set; }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new {data = await _db.journal.ToListAsync() });
        }

        public async Task<IActionResult> Delete()
        {
            var journalFromDb = await _db.journal.FindAsync(journals.EntryID);
            if(journalFromDb == null)
            {
                return Json(new { success = false, message = "No Records to Delete" });

            }
            else
            {
                _db.journal.Remove(journalFromDb);
                await _db.SaveChangesAsync();
                return Json(new { success = true, message = "Deleted Record!" });
            }
        }


    }
}
