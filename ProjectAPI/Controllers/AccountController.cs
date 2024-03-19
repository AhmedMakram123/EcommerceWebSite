using EcommerceWebSite.Context;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> usermanger;
        private readonly IConfiguration config;
        public AccountController(UserManager<ApplicationUser> usermanger, IConfiguration config)
        {
            this.usermanger = usermanger;
            this.config = config;
        }

        //Create Account new User "Registration" "Post"
        [HttpPost("addAdmin")]//api/account/register
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> addAdmin(RegisterUserDto userDto)
        {
            if (ModelState.IsValid)
            {
                //save
                ApplicationUser user = new ApplicationUser();
                user.UserName = Guid.NewGuid().ToString();
                user.fName = userDto.fName;
                user.lName = userDto.lName; 
                user.PasswordHash = userDto.password;
                user.PhoneNumber = userDto.PhoneNumber;
                user.Email = userDto.email;
                IdentityResult result = await usermanger.CreateAsync(user, userDto.password);
                if (result.Succeeded)
                {
                    await usermanger.AddToRoleAsync(user, "Admin");
                    return Ok("Admin Add Success");
                }
                return BadRequest(result.Errors.FirstOrDefault());
            }
            return BadRequest(ModelState);
        }

        [HttpPost("addSeller")]//api/account/register
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> addSeller(RegisterUserDto userDto)
        {
            if (ModelState.IsValid)
            {
                //save
                ApplicationUser user = new ApplicationUser();
                user.UserName = Guid.NewGuid().ToString();
                user.fName = userDto.fName;
                user.lName = userDto.lName; 
                user.PasswordHash = userDto.password;
                user.PhoneNumber = userDto.PhoneNumber;
                user.Email = userDto.email;
                IdentityResult result = await usermanger.CreateAsync(user, userDto.password);
                if (result.Succeeded)
                {
                    await usermanger.AddToRoleAsync(user, "Seller");
                    return Ok("Seller Add Success");
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

        [HttpPost("register")]//api/account/register
        public async Task<IActionResult> register(RegisterUserDto userDto)
        {
            if (ModelState.IsValid)
            {
                //save
                ApplicationUser user = new ApplicationUser();
                user.UserName = Guid.NewGuid().ToString();
                user.fName= userDto.fName;
                user.lName= userDto.lName;
                user.PasswordHash = userDto.password;
                user.PhoneNumber = userDto.PhoneNumber;
                user.Email = userDto.email;
                IdentityResult result = await usermanger.CreateAsync(user, userDto.password);
                if (result.Succeeded)
                {
                    await usermanger.AddToRoleAsync(user, "Customer");
                    return Ok("Customer Add Success");
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

        //Check Account Valid "Login" "Post"
        [HttpPost("login")]//api/account/login
        public async Task<IActionResult> Login(LoginUserDto userDto)
        {
            if (ModelState.IsValid == true)
            {
                //check - create token
                ApplicationUser user = await usermanger.FindByEmailAsync(userDto.UserEmail);
                if (user != null)//user name found
                {
                    bool found = await usermanger.CheckPasswordAsync(user, userDto.Password);
                    if (found)
                    {
                        //Claims Token
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        //get role
                        var roles = await usermanger.GetRolesAsync(user);
                        foreach (var itemRole in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, itemRole));
                        }
                        SecurityKey securityKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));

                        SigningCredentials signincred =
                            new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        //Create token
                        JwtSecurityToken mytoken = new JwtSecurityToken(
                            issuer: config["JWT:ValidIssuer"],//url web api
                            audience: config["JWT:ValidAudiance"],//url consumer angular
                            claims: claims,
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: signincred
                            );
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                            expiration = mytoken.ValidTo
                        });
                    }
                }
                return Unauthorized();

            }
            return Unauthorized();
        }


    }
}
