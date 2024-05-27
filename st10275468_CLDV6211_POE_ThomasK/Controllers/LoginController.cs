using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;

namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class LoginController : Controller
    {
        
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
       

        [HttpPost]
        public ActionResult Log(string name, string password)
        {

            var loginModel = new Login();
            int userID = loginModel.SelectUser(name, password);
            if (userID != -1)
            {

               HttpContext.Session.SetInt32("UserID", userID);
                _httpContextAccessor.HttpContext.Session.SetString("UserName", name);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                TempData["InvalidLogin"] = true;
                return RedirectToAction("Index","Home");
            }

        }


        
    }
}
