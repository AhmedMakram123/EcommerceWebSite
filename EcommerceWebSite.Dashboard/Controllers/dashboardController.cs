using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebSite.Dashboard.Controllers
{
    public class dashboardController : Controller
    {
        public IActionResult dashboard()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
