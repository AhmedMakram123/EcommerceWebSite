using Microsoft.AspNetCore.Http;
using EcommerceWebSite.Domain.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManger;

        public RoleController(RoleManager<IdentityRole> _roleManger)
        {
            roleManger = _roleManger;
        }
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(RoleDto RoleDto)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = RoleDto.RoleName;
                IdentityResult result = await roleManger.CreateAsync(role);
                if (result.Succeeded)
                {
                    return Ok("Role Add Success");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        return BadRequest(item);
                    }
                }
            }
            return BadRequest(ModelState);
        }
        
    }
}
