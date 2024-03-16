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
   
    public class SubCategoryRepository : BaseRepository<SubCategory, int>, ISubCategoryRepository
    {
        public SubCategoryRepository(EcommerceContext _context) : base(_context)
        {

        }
    }
}
