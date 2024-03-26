using EcommerceWebSite.Domain.DTOs.Products;
using EcommerceWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.DTOs
{
    public class CreateOrUpdateSubCategoryDTO
    {
      
        public Guid Id { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = " Arabic name is required.")]
        [MaxLength(50, ErrorMessage = "Product name cannot exceed 50 characters.")]
        public string ArName { get; set; }
        [Required(ErrorMessage = " English name is required.")]
        [MaxLength(50, ErrorMessage = "Product name cannot exceed 50 characters.")]
        public string EnName { get; set; }

      
    }
}
