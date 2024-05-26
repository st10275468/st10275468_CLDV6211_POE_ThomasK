using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;

namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class DisplayMyProductsOrdersController1 : Controller
    {
        [HttpGet]
        public IActionResult ProductsOrders()
        {
            var MyProductOrders = DisplayMyProductOrders.SelectMyProductOrders();
            return View(MyProductOrders);
        }
    }
}
