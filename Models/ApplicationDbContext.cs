using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace RazorPage.Models
{
    public class ApplicationDbContext : DbContext
    {
        /*Pass DbContext options to parent class*/
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        //Add Model
        //After adding all the models next is to add it to the startup class
        public DbSet<Journal> journal{ get; set; }
    }
}
