using Microsoft.EntityFrameworkCore;   // importing dependencies 



using mvc_app2.Models;

public class ApplicationDbContext : DbContext     //inheritance
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Intern> Interns { get; set; }
       
    }


