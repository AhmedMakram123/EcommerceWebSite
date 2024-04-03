using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.DTOs
{
    public class CreateOrUpdateCategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " Arabic name is required.")]
        public string ArName { get; set; }
        [Required(ErrorMessage = " English name is required.")]
        public string EnName { get; set; }
        public string imgURL { get; set; }
        public string? imgURLAr { get; set; }
    }
}
