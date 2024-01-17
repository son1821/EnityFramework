using EF1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Extensions.Logging;
using System.Text;

namespace EF1
{
    class Program
    {

        //Tao database
        static void CreateDb()
        {
            using var dbcontext = new ShopContext();
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
            using var dbcontext = new ShopContext();
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

        static void InsertData()
        {
            using var dbcontext = new ShopContext();
            Category category = new Category() { Name = "dien thoai", Description = "Cac loai dien thoai" };
            Category category1 = new Category() { Name = "may tinh", Description = "Cac loai may tinh" };
            dbcontext.Add(category);
            dbcontext.Add(category1);

            var c1 = (from c in dbcontext.category where c.CategoryId == 1 select c).FirstOrDefault();
            var c2 = (from c in dbcontext.category where c.CategoryId == 2 select c).FirstOrDefault();
            dbcontext.Add(new Product() { Name = "Iphone", Price = 1000, CateId = 1 });
            dbcontext.Add(new Product() { Name = "SamSung", Price = 2000, CateId = 1 });
            dbcontext.Add(new Product() { Name = "Lenovo", Price = 3000, CateId = 2 });
            dbcontext.Add(new Product() { Name = "Macbook", Price = 4000, CateId = 2 });
            dbcontext.Add(new Product() { Name = "Oppo", Price = 1000, CateId = 1 });
            dbcontext.Add(new Product() { Name = "Remid", Price = 2000, CateId = 1 });
            dbcontext.Add(new Product() { Name = "Dell", Price = 3000, CateId = 2 });
            dbcontext.Add(new Product() { Name = "Asus", Price = 4000, CateId = 2 });
            dbcontext.SaveChanges();
           
          

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            //DropDb();
            //CreateDb();

            //InsertData();

            //using var dbcontext = new ShopContext();

            //var category = (from c in dbcontext.category where c.CategoryId == 1 select c).FirstOrDefault();
            //dbcontext.Remove(category);
            //dbcontext.SaveChanges();


            //if(category.product != null)
            //{
            //    for(int i = 0; i<category.product.Count;i++)
            //    {
            //        category.product[i].PrinProduct();
            //    }
            //}

            //var product = (from c in dbcontext.products where c.ProductId == 3 select c).FirstOrDefault();
            //var cate = dbcontext.Entry(product);
            //cate.Reference(p => p.Category).Load();

            //product.PrinProduct();
            //if (product.Category != null)
            //{
            //    Console.WriteLine($"{product.Category.Name} - {product.Category.Description}");
            //}
            //else Console.WriteLine("Category = null");
            using var dbcontext = new ShopContext();
            //var kq = dbcontext.products.Find(5);
            //kq.PrinProduct();
            var kq = from p in dbcontext.products
                     join c in dbcontext.category
                     on p.CateId equals c.CategoryId
                     select new
                     {
                         ten = p.Name,
                         danhmuc = c.Name,
                         gia = p.Price
                     };
            kq.ToList().ForEach(x => Console.WriteLine($"{x.ten} - {x.danhmuc} - {x.gia}"));
           
        }
    }
}