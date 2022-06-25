using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FifyFiveShop.Pages.Controllers
{
    public class ProductController : Controller
    {
        [Route("api/Products")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
