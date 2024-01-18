

using EF1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EF1
{
    public class ShopContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();       
         }
            );
        public DbSet<Product> products { get; set; }
        public DbSet<Category> category {  get; set; }

        public DbSet<Category>categories { get; set; }
        private const string connectionString = @"
            Data Source=localhost,1433;
            Initial Catalog=shopdata; 
            User ID=SA;
            Password=Password123";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
            
       
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Fluent API

            // var entity = modelBuilder.Entity(typeof(Product)); cach 1
            // var entity =modelBuilder.Entity<Product>() cach 2
            modelBuilder.Entity<Product>(entity =>
            {//table mapping
                entity.ToTable("Sanpham");
                //Pk
                entity.HasKey(p => p.ProductId);

                //index
                entity.HasIndex(p => p.Price).HasDatabaseName("index-sanpham-price");

                //reltive
                entity.HasOne(p => p.Category)
                
                .WithMany() //category khong có property  chứa  tap hop  san pham fk tao ra
                .HasForeignKey("CateId") //dat ten fk
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Khoa_ngoai_Sanpham_Category");

                entity.HasOne(p => p.Category2)
                .WithMany(c => c.products) //collect navigation
                .HasForeignKey("CateId2")
                .OnDelete(DeleteBehavior.NoAction);

                entity.Property(p => p.Name)
                .HasColumnName("title")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired(true)
                .HasDefaultValue("Ten san pham mac dinh");
 

            });
            //1-1
            modelBuilder.Entity<CategoryDetails>(entity =>
            {
                entity.HasOne(c => c.Category)
                .WithOne(d => d.categoryDetails)
                .HasForeignKey<CategoryDetails>(e => e.CategoryDetailId)
                .OnDelete(DeleteBehavior.Cascade);

            });
          
        }


    }
}
