using EcommerceWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.DTOs
{
    public class GetAllCategoryDTO
    {
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public string imgURL { get; set; }
        public string? imgURLAr { get; set; }
        public List<GetAllSubCategoryDTO>? subCategories { get; set; }
     }
}
