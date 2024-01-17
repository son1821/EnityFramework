using EF1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text;

namespace EF1
{
    class Program
    {
        //Tao database
        static void CreateDb()
        {
            using var dbcontext = new ProductDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            var kq = dbcontext.Database.EnsureCreated();
            if (kq)
            {
                Console.WriteLine($"Tao db {dbname} thanh cong");

            }
            else
            {
                Console.WriteLine($"khong tao duoc db {dbname}");
            }
        }
        static void DropDb()
        {
            using var dbcontext = new ProductDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            var kq = dbcontext.Database.EnsureDeleted();
            if (kq)
            {
                Console.WriteLine($"Xoa db {dbname} thanh cong");

            }
            else
            {
                Console.WriteLine($"khong xoa duoc db {dbname}");
            }
        }

        static void InsertProduct()
        {
            using var dbcontext = new ProductDbContext();
            /*
             - tao Model (Product)
             - gọi Add, AddAsyc
            - gọi SaveChange
             */
            //var p1 = new Product()
            //{
            //    ProductName = "Sản phẩm 2",
            //    Provider = "Công ty 2"
            //};
            //dbcontext.Add( p1 );
            var products = new object[]
            {
                new Product(){ProductName = "Sản phẩm 3",Provider = "Công ty 3"},
            new Product() { ProductName = "Sản phẩm 4", Provider = "Công ty 4" },
                new Product(){ProductName = "Sản phẩm 5",Provider = "Công ty 5"}
            };
            dbcontext.AddRange(products);

           int number_rows =  dbcontext.SaveChanges();
            Console.WriteLine($"Da chen {number_rows} du lieu");
            
        }
        static void ReadProduct()
        {
            using var dbcontext = new ProductDbContext();
            //linq de truy van du lieu
            //var products =  dbcontext.products.ToList();
            // products.ForEach(product =>

            //     product.PrinProduct()
            // );

            //var qr = from product in dbcontext.products
            //         where product.Provider.Contains("Công ty")
            //         orderby product.ProductId descending
            //    select product;
            //qr.ToList().ForEach(p => p.PrinProduct());

            Product product = (from p in dbcontext.products
                              where p.ProductId == 4 
                              select p).FirstOrDefault();
            if(product != null)
            {
                product.PrinProduct();
            }
                

        }
        static void ReNameProduct(int id,string newName)
        {
            using var dbcontext = new ProductDbContext();
            Product product = (from p in dbcontext.products
                               where p.ProductId == id
                               select p).FirstOrDefault();
            if (product != null)
            {
                product.ProductName = newName;
                int number_rows = dbcontext.SaveChanges();
                Console.WriteLine($"Da cap nhat {number_rows} du lieu");
            }
        }
        static void DeleteProduct(int id)
        {
            using var dbcontext = new ProductDbContext();
            Product product = (from p in dbcontext.products
                               where p.ProductId == id
                               select p).FirstOrDefault();
            if (product != null)
            {
                dbcontext.Remove(product);
                int number_rows = dbcontext.SaveChanges();
                Console.WriteLine($"Da xoa {number_rows} du lieu");
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            //CreateDb();
            //DropDb();

            //insert, select, update, delete
            //InsertProduct();
            //ReadProduct();
            ReNameProduct(2, "Nước Mắm");
            //DeleteProduct(1);

            // logging

        }
    }
}