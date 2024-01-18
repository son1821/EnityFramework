

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF1.Model
{
    [Table("Products")]

    public class Product
    {
        
        
        //[Key]
        public int ProductId {  get; set; }

        
        [StringLength(50)]
        
        [Column("Tensanpham",TypeName ="ntext")]
        public string Name { get; set; }


        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int CateId {  get; set; }
        
        //Reference Navigation
        //Tao ra foreign key
        //[ForeignKey("CateId")]
        
        
        public virtual Category Category { get; set; }
        public int? CateId2 { get; set; }
        //[ForeignKey("CateId2")]
        //[InverseProperty("products")]
        public virtual Category Category2 { get; set; }
        public void PrinProduct()
        {
           
            Console.WriteLine($"{ProductId} - {Name} - {Price} - {CateId}");
            
        }
    }
}
/*
 [Table("TableName")] - Chi ra model tuong ung table tren database
[Key] -> Primary Key
[Required] -> Not null
[StringLenght(50)] -> do dai 
[Column("Tensanpham"TypeName ="ntext")]
[ForeignKey("CateId")]
Reference Navigation ->ForeignKey(1-nhieu) (tham chieu tu 1 model nay den 1 model khac)
Collect Navigation -> (Khong tao ra foreignkey)

Inverse Property


 */