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
        
        [DisplayName("Notizen")]
        public string Description { get; set; }
        public long EAN { get; set; }
        
        [DisplayName("Kategorie")]
        public int CategoryId { get; set; }        
        public virtual Category Category { get; set; }
    }
}