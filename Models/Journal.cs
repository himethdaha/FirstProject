using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPage.Models
{
    public class Journal
    {
        [Key]
        public int EntryID { get; set; }

        [Required]
        public string EntryName { get; set; }
        [Required]
        public string EntryDescription { get; set; }
        [Required]
        public DateTime EntryDate { get; set; }
        public bool StarredEntry { get; set; }
    }
}
