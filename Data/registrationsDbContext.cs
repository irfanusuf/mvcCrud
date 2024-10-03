using Microsoft.EntityFrameworkCore;   // importing dependencies 

using mvcRegistrations.Models;   //importing models 

public class registrationsDbContext : DbContext     //inheritance
{
    public registrationsDbContext(DbContextOptions<registrationsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Intern> Interns { get; set; }
    public DbSet<CartModel> CartModels { get; set; }
    public DbSet<ProductModel> ProductModels { get; set; }
   
}