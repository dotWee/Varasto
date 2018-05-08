﻿using System;
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
        public string Description { get; set; }
    }
}