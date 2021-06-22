using Microsoft.EntityFrameworkCore;
using MADomain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MAData
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(e =>
            {
                e.Property(a => a.Price).HasColumnType("decimal(18, 8)");
            });

            builder.Entity<ProductCategory>()
                .HasKey(x => new { x.CategoryId, x.ProductId });

            builder.Entity<ProductTag>()
                .HasKey(x => new { x.TagId, x.ProductId });
            base.OnModelCreating(builder);
        }
    }
}