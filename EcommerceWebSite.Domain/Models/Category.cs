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
        public string ArName { get; set;}
        [Required(ErrorMessage = " English name is required.")]
        public string EnName { get; set;}
        public string? imgURL { get; set;}
        public string? imgURLAr { get; set;}
        public List<SubCategory> SubCategories { get; set;}
    }
}
