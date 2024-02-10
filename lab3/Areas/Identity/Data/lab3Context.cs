using lab3.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using lab3.Models;

namespace lab3.Data;

public class lab3Context : IdentityDbContext<lab3User>
{
    private class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<lab3User>
    {
        public void Configure(EntityTypeBuilder<lab3User> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(255);
            builder.Property(x => x.LastName).HasMaxLength(255);
        }
    }
    public lab3Context(DbContextOptions<lab3Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<lab3.Models.kontrola> kontrola { get; set; } = default!;

public DbSet<lab3.Models.fly> fly { get; set; } = default!;
}
