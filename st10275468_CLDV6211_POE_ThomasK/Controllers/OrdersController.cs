using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;

namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class OrdersController : Controller
    {
        public Orders ordertbl = new Orders();
        [HttpGet]
        public ActionResult MyOrders()
        {
            return View(ordertbl);
        }
    }
}
