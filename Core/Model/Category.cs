using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Varasto.Core.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}