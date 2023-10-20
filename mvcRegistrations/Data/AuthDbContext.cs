using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace mvcRegistrations.Data
{
    public class AuthDbContext : IdentityDbContext<IdentityUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Roles (User, Admin, etc)
            var adminRoleID = "2f5a6ee7-758d-49a4-bfaa-e93ab61f78f0";
            var userRoleID = "fb7a0d52-ed67-485a-8d3a-0739deacf388";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",  // Change role name to uppercase
                    Id = adminRoleID,
                    ConcurrencyStamp = adminRoleID
                },

                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",   // Change role name to uppercase
                    Id = userRoleID,
                    ConcurrencyStamp = userRoleID
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Seed admin user
            var adminID = "07a6a7ab-7c03-4a37-8866-4e89661c3a71";
            var adminID2 = "07a6a7ab-7c03-4a37-8866-4e89661c3a72";

            var adminUser = new IdentityUser
            {
                UserName = "irfanusuf33@gmail.com",
                Email = "irfanusuf33@gmail.com",
                NormalizedEmail = "irfanusuf33@gmail.com".ToUpper(),
                NormalizedUserName = "irfanusuf33@gmail.com".ToUpper(),
                Id = adminID
            };

            var adminUser2 = new IdentityUser
            {
                UserName = "hidsaan",
                Email = "hidsaan33@gmail.com",
                NormalizedEmail = "hidsaan".ToUpper(),
                NormalizedUserName = "hidsaan33@gmail.com".ToUpper(),
                Id = adminID2
            };

            adminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adminUser, "AdminUser11@");
            adminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adminUser2, "AdminUser22@");

            builder.Entity<IdentityUser>().HasData(adminUser);  // Use builder.Entity<IdentityUser>() for user data

            // Add all roles to admin
            var adminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = userRoleID,
                    UserId = adminID
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleID,
                    UserId = adminID
                }
                ,
                new IdentityUserRole<string>
                {
                    RoleId = userRoleID,
                    UserId = adminID2
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleID,
                    UserId = adminID2
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);  // Use builder.Entity<IdentityUserRole<string>>() for role assignment
        }
    }
}
