using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;

namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class DisplayOrdersController : Controller
    {
        [HttpGet]
        public IActionResult MyOrders()
        {
            var Orders = DisplayOrders.SelectOrders();
           
           return View(Orders);

        }
    }
}
