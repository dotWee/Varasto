using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Varasto.Core.Model
{
    public class Category
    {
        [Key]
        [DisplayName("ID")]
        public int CategoryId { get; set; }
        
        [DisplayName("Name")]
        public string Name { get; set; }
        
        [DisplayName("Produkte")]
        public virtual ICollection<Product> Products { get; set; }
    }
}