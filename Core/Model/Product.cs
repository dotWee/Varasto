﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Varasto.Core.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EuropeanArticleNumber { get; set; }
        
        public Category Category { get; set; }
        public List<Label> Labels { get; set; }
    }
}