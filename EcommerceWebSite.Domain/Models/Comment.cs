using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.Models
{
    public class Comment : BaseEntity
    {

        [Required(ErrorMessage = "Review is required.")]
        [MaxLength(1000, ErrorMessage = "Review cannot exceed 1000 characters.")]
        public string review { get; set; }

        [Required(ErrorMessage = "Quality is required.")]
        [Range(0, 5, ErrorMessage = "Quality must be between 0 and 5.")]
        public decimal quality { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
