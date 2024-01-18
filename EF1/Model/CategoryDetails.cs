using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF1.Model
{
    public class CategoryDetails
    {
        [Key]
        public int CategoryDetailId { get; set; }
        public int UserId { get; set; }
        public DateTime Create { get; set; }
        public DateTime Update { get; set; }
        public int CountProduct { get; set; }
        public virtual Category Category { get; set; }
    }
}
