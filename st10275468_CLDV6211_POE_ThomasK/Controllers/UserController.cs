using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;

namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class UserController : Controller
    {
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
            return View(userTbl);
        }
      

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
