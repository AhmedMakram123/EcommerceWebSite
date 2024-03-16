using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.DTOs
{
   public class RoleDto
    {
        [Required]
        [Display(Name = "Enter The Role Name")]
        public string RoleName { set; get; }
    }
}
