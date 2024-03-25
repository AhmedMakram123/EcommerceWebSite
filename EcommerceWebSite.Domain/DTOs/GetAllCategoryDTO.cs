using EcommerceWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.DTOs
{
    public class GetAllCategoryDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<SubCategory>? subCategories { get; set; }
}
}
