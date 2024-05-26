using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using st10275468_CLDV6211_POE_ThomasK.Models;
using System.Diagnostics;

namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            int? UserID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            ViewData["UserID"] = UserID;
            return View();
            
        }

        public IActionResult ShopProducts()
        {
            var userID = HttpContext.User.Identity.Name;
            List<Products> products = Products.GetProducts();
            ViewData["products"] = products;
            ViewData["UserID"] = userID;

            return View();
        }
        public IActionResult MyOrders()
        {
            int? UserID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            List<Orders> orders = Orders.GetOrders(UserID);
            
           

            return View(orders);

        }
        public IActionResult ProductsOrders()
        {
            int? UserID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            List<MyProductsOrders> productOrders = MyProductsOrders.GetMyProductsOrders(UserID);

            return View(productOrders);
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult MyProductsPage()
        {
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            List<MyProducts> myProducts = MyProducts.GetMyProducts(userID);
            return View(myProducts);
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult MyWork()
        {
            return View();
        }
      



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
