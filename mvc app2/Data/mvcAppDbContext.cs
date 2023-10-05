using Microsoft.EntityFrameworkCore;
using mvc_app2.Models;

public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Intern> Interns { get; set; }
    }


