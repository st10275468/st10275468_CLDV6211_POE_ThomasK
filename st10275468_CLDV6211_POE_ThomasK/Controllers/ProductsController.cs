using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;

namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class ProductsController : Controller
    {
        public Products producttbl = new Products();




        [HttpPost]
        public ActionResult MyWork(Products Products)
        {
            var result2 = producttbl.insert_product(Products);
            return RedirectToAction("Index", "Home");


        }

        [HttpGet]
        public ActionResult MyWork()
        {
            return View(producttbl);
        }


      
    }
}
