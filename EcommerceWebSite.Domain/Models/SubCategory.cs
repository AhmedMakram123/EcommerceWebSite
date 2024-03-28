using System;
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
      

      

        [Required(ErrorMessage = " Arabic name is required.")]
        [MaxLength(50, ErrorMessage = "Product name cannot exceed 50 characters.")]
        public string ArName { get; set; }

        [Required(ErrorMessage = " English name is required.")]
        [MaxLength(50, ErrorMessage = "Product name cannot exceed 50 characters.")]
        public string EnName { get; set; }

        //Relations
        public virtual ICollection<Product> Products { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
