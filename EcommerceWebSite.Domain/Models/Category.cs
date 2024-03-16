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
        [Required(ErrorMessage = " Arabic name is required.")]
        [MaxLength(50, ErrorMessage = "Category name cannot exceed 50 characters.")]
        public string ArName { get; set; }

        [Required(ErrorMessage = " English name is required.")]
        [MaxLength(50, ErrorMessage = "Category name cannot exceed 50 characters.")]
        public string EnName { get; set; }

        public virtual ICollection<SubCategory> SubCategorys { get; set; }

    }
}
