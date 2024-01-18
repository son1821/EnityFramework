using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF1.Model
{
    [Table("Category")]
    public class Category
    {
        [Key]
         public int CategoryId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName ="ntext")]
        public string Description { get; set; }
        //collect navigation
        public virtual List<Product> products { get; set; }
        public virtual CategoryDetails categoryDetails { get; set; }
    
    
    }
}
