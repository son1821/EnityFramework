

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


    }
}
