using EcommerceWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Contract
{
    public interface ISubCategoryRepository:IBaseRepository<SubCategory,int>
    {
    }
}
