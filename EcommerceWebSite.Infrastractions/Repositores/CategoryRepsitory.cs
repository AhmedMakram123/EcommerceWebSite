using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Context;
using EcommerceWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Infrastractions.Repositores
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(EcommerceContext _context) : base(_context)
        {

        }
    }
}
