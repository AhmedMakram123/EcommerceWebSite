
using EcommerceWebSite.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace EcommerceWebSite.Context
{
    public class EcommerceContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public EcommerceContext()
        {
        }
        public EcommerceContext(DbContextOptions options) : base(options)
        {
        }

    }

}
