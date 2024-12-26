using Microsoft.EntityFrameworkCore;
using PamukkaleKagit.Domain.Entities;
using Type = PamukkaleKagit.Domain.Entities.Type;

namespace PamukkaleKagit.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<CategoryImage> CategoriesImages { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductTypeJunction> ProductTypeJunctions { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Category tablosu için yapılandırma
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description);
                //entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // SubCategory için yapılandırma
            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.ToTable("SubCategories");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description);
                entity.Property(e => e.Image);
                entity.HasOne(e => e.Category)
                      .WithMany(c => c.SubCategories)
                      .HasForeignKey(e => e.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            //CategoryImage için yapılandırma
            modelBuilder.Entity<CategoryImage>(entity =>
            {
                entity.ToTable("CategoryImages");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name);
                entity.Property(e => e.Image).IsRequired().HasMaxLength(500);
                entity.HasOne(e => e.Category)
                      .WithMany(c => c.CategoryImages)
                      .HasForeignKey(e => e.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Brand için yapılandırma
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brands");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Icon);
                entity.HasMany(e => e.Products)
                      .WithOne(p => p.Brand)
                      .HasForeignKey(p => p.BrandId)
                      .OnDelete(DeleteBehavior.Cascade); 
            });

            // Product için yapılandırma
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Package).IsRequired();
                entity.Property(e => e.Box);
                entity.Property(e => e.IsActive).IsRequired();
                entity.Property(e => e.OurSelected).IsRequired();

                entity.HasOne(e => e.SubCategory)
                      .WithMany(s => s.Products)
                      .HasForeignKey(e => e.SubCategoryId)
                      .OnDelete(DeleteBehavior.Restrict); // Alt kategori silinse bile ürünler korunur

                entity.HasOne(e => e.Brand)
                      .WithMany(b => b.Products)
                      .HasForeignKey(e => e.BrandId)
                      .OnDelete(DeleteBehavior.Cascade); // Marka silindiğinde ürünler de silinir

                entity.HasMany(e => e.ProductTypes)
                      .WithOne(pt => pt.Product)
                      .HasForeignKey(pt => pt.ProductId)
                      .OnDelete(DeleteBehavior.Cascade); 

                entity.HasMany(e => e.ProductAttributes)
                      .WithOne(pa => pa.Product)
                      .HasForeignKey(pa => pa.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Type için yapılandırma
            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Types");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Symbol).IsRequired().HasMaxLength(50);

                entity.HasMany(e => e.ProductTypes)
                      .WithOne(pt => pt.Type)
                      .HasForeignKey(pt => pt.TypeId)
                      .OnDelete(DeleteBehavior.Cascade); 
            });

            // ProductType için yapılandırma
            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("ProductTypes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Value).IsRequired();
                entity.Property(e => e.Text);

                entity.HasOne(e => e.Type)
                      .WithMany(t => t.ProductTypes) 
                      .HasForeignKey(e => e.TypeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            #region ProductTypeJunction Ayarları
            modelBuilder.Entity<ProductTypeJunction>()
                .HasKey(pt => pt.Id);

            modelBuilder.Entity<ProductTypeJunction>()
                .HasOne(pt => pt.Product)
                .WithMany(t => t.ProductTypes)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductTypeJunction>()
                .HasOne(pt => pt.ProductType)
                .WithMany(p => p.Products)
                .HasForeignKey(pt => pt.ProductTypeId);
            #endregion

            // ProductAttribute için yapılandırma
            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.ToTable("ProductAttributes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Value);

                entity.HasOne(e => e.Product)
                      .WithMany(p => p.ProductAttributes) 
                      .HasForeignKey(e => e.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
