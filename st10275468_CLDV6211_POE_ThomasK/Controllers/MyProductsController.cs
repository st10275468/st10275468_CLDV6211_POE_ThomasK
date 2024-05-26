using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;
namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class MyProductsController : Controller
    {
        public MyProductsController producttbl = new MyProductsController();
        [HttpGet]
        public ActionResult MyProductsPage()
        {
            return View(producttbl);
        }
    }
}
