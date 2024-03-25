using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.DTOs
{
    public class CreateOrUpdateCategoryDTO
    {
       public int Id { get; set; }
       public string? Name { get; set; }
       public List<CreateOrUpdateSubCategoryDTO> SubCategories { get; set; }
    }
}
