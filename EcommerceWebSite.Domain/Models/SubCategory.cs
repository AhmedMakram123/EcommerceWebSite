﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.Models
{
    public class SubCategory : BaseEntity
    {
        [MaxLength(50)]
        [Required]
        public String? Name { get; set; }

        //Relations
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
