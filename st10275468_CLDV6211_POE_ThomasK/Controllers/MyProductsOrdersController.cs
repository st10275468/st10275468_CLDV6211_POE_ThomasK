using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;

namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class MyProductsOrdersController : Controller
    {
        public MyProductsOrders ordertbl = new MyProductsOrders();
        [HttpGet]
        public ActionResult ProductsOrders()
        {
            return View(ordertbl);
        }
        

    }
}
