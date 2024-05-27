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
        private void SetUserIDInViewData()
        {
            int? UserID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            ViewData["UserID"] = UserID;
        }
        public IActionResult Index()
        {
            SetUserIDInViewData();
            string UserName = _httpContextAccessor.HttpContext.Session.GetString("UserName");
            
            ViewData["UserName"] = UserName;
            
            return View();

        }
      

        public IActionResult ShopProducts()
        {
            SetUserIDInViewData();
            List<Products> products = Products.GetProducts();
            ViewData["products"] = products;
            

            return View();
        }
        public IActionResult MyOrders()
        {
            SetUserIDInViewData();
            int? UserID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            List<Orders> orders = Orders.GetOrders(UserID);
            
           

            return View(orders);

        }
        public IActionResult ProductsOrders()
        {
            SetUserIDInViewData();
            int? UserID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            List<MyProductsOrders> productOrders = MyProductsOrders.GetMyProductsOrders(UserID);

            return View(productOrders);
        }
        public IActionResult AboutUs()

        {
            SetUserIDInViewData();
            return View();
        }
        public IActionResult MyProductsPage()
        {
            SetUserIDInViewData();
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            List<MyProducts> myProducts = MyProducts.GetMyProducts(userID);
            return View(myProducts);
        }

        public IActionResult ContactUs()
        {
            SetUserIDInViewData();
            return View();
        }

        public IActionResult MyWork()
        {
            SetUserIDInViewData();
            return View();
        }
      



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            SetUserIDInViewData();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
