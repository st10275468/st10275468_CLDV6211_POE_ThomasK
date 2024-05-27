using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;
using Microsoft.AspNetCore.Identity;
namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class ProductsController : Controller
    {
        public Products producttbl = new Products();




        [HttpPost]
        public ActionResult MyWork(Products Products)
        {
            
            int? UserID = HttpContext.Session.GetInt32("UserID");
            var result2 = producttbl.insert_product(Products, UserID);
           
            return RedirectToAction("MyWork", "Home");


        }

        [HttpGet]
        public ActionResult MyWork()
        {
            return View(producttbl);
        }

       

    }
}
