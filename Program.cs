using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Assignment_5.Data;

var builder = WebApplication.CreateBuilder(args);

// Retrieve the connection string from configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Configure EF Core to use your SQLite database file (app.db)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Helpful exception page for EF Core errors in Development
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configure ASP.NET Identity (login/registration) using EF Core stores
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add support for MVC controllers and Razor views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();      // apply pending migrations at startup
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Default route for MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Routes for Razor Pages (Identity UI)
app.MapRazorPages();

app.Run();
