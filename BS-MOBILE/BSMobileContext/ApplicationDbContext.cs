using BS_MOBILE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BS_MOBILE.BSMobileContext
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<MobileModel> MobileModels { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Unique constraints
            builder.Entity<Brand>().HasIndex(b => b.Name).IsUnique();
            builder.Entity<StockItem>().HasIndex(s => s.IMEI).IsUnique();
            builder.Entity<Sale>().HasIndex(s => s.InvoiceNo).IsUnique();

            // Brand 1 : many MobileModel
            builder.Entity<MobileModel>()
                .HasOne(m => m.Brand)
                .WithMany(b => b.MobileModels)
                .HasForeignKey(m => m.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            // MobileModel 1 : many StockItem
            builder.Entity<StockItem>()
                .HasOne(s => s.MobileModel)
                .WithMany(m => m.StockItems)
                .HasForeignKey(s => s.MobileModelId)
                .OnDelete(DeleteBehavior.Restrict);

            // ApplicationUser 1 : many Sale
            builder.Entity<Sale>()
                .HasOne(s => s.SoldBy)
                .WithMany()
                .HasForeignKey(s => s.SoldById)
                .OnDelete(DeleteBehavior.Restrict);

            // Sale 1 : many SaleItem
            builder.Entity<SaleItem>()
                .HasOne(si => si.Sale)
                .WithMany(s => s.SaleItems)
                .HasForeignKey(si => si.SaleId)
                .OnDelete(DeleteBehavior.Cascade);

            // StockItem 1 : 0..1 SaleItem (ek phone sirf ek dafa bik sakta hai)
            builder.Entity<SaleItem>()
                .HasOne(si => si.StockItem)
                .WithOne(s => s.SaleItem)
                .HasForeignKey<SaleItem>(si => si.StockItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // Decimal precision
            builder.Entity<MobileModel>().Property(m => m.SalePrice).HasPrecision(18, 2);
            builder.Entity<StockItem>().Property(s => s.CostPrice).HasPrecision(18, 2);
            builder.Entity<Sale>().Property(s => s.Discount).HasPrecision(18, 2);
            builder.Entity<Sale>().Property(s => s.TotalAmount).HasPrecision(18, 2);
            builder.Entity<SaleItem>().Property(si => si.SalePrice).HasPrecision(18, 2);
        }
    }
}
