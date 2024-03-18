using EcommerceWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Contract
{
    public interface IUserRepository : IBaseRepository<ApplicationUser, int>
    {
        ApplicationUser GetByEmail(string email);
        ApplicationUser Login(string email, string password);

    }
}
