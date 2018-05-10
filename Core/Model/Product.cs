using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Varasto.Core.Model
{
    public class Product
    {
        [Key]
        [DisplayName("ID")]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EAN { get; set; }
        
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}