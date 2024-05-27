using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;

namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        private void SetUserIDInViewData()
        {
            int? UserID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            ViewData["UserID"] = UserID;
        }
        public Users userTbl = new Users();

        [HttpPost]
        public ActionResult About(Users users)
        {
            var result = userTbl.insert_User(users);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult About()
        {
            SetUserIDInViewData();
            return View(userTbl);
        }
      

        public IActionResult Index()
        {
            SetUserIDInViewData();
            return View();
        }
        public IActionResult AboutUs()
        {
            SetUserIDInViewData();
            return View();
        }
    }
}
