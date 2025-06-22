using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assignment_5.Models;

namespace Assignment_5.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Event> Events { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
