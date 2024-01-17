

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF1.Model
{
    [Table("product")]

    public class Product
    {
        
        
        [Key]
        public int ProductId {  get; set; }

        
        [StringLength(50)]
        public string ProductName { get; set; }
        
        [StringLength(50)]
        public string? Provider { get; set; }
        public void PrinProduct()
        {
           
            Console.WriteLine($"{ProductId} - {ProductName} - {Provider}");
            
        }
    }
}
