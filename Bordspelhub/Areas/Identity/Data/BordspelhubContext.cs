using Bordspelhub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bordspelhub.Data;

public class BordspelhubContext : IdentityDbContext<IdentityUser>
{
    public BordspelhubContext(DbContextOptions<BordspelhubContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Spel> Spellen { get; set; }
    public DbSet<Gebruiker> Gebruikers { get; set; }
    public DbSet<Evenement> Evenementen { get; set; }
}
