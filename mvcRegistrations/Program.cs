using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using mvcRegistrations.Data;

var builder = WebApplication.CreateBuilder(args);

// adding Services 
builder.Services.AddControllersWithViews();


// adding db context
builder.Services.AddDbContext<registrationsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDbConnection")));

builder.Services.AddDbContext<AuthDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDbConnection")));


// configuring the identity 


builder.Services.AddIdentity<IdentityUser, IdentityRole>()       // identity framework
  .AddEntityFrameworkStores<AuthDbContext>();


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireDigit = true;

});


var app = builder.Build();

// Configure middleware.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Add authentication and authorization middleware.
app.UseAuthentication();
app.UseAuthorization();




// mapping default route 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
