using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.Models
{
    public class Category : BaseEntity
    {
        [MaxLength(50)]
        [Required]
        String? Name { get; set; }

    }
}
