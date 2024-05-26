using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;
namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class DisplayMyProductsController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DisplayMyProductsController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult MyProductsPage()
        {
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
             
            var myProduct = DisplayMyProduct.SelectMyProducts(userID);
           
            return View(myProduct);
        }
    }
}
