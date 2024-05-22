using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;

namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class LoginController : Controller
    {
        private readonly Login loginM;

        public LoginController()
        {
            loginM = new Login();
        }

        [HttpPost]
        public ActionResult Privacy(string name, string password)
        {
            var loginModel = new Login();
            int userID = loginModel.SelectUser(name, password);
            if (userID != -1)
            {

                HttpContext.Session.SetInt32("UserID", userID);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View("LoginFailed");
            }

        }

        
    }
}
