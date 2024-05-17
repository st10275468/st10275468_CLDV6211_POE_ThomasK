using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;

namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class DisplayProductsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var Products = DisplayProducts.SelectProducts();
            return View(Products);
        }
    }
}
