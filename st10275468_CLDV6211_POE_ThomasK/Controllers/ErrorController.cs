using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;
using System.Diagnostics;
namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            var errorViewModel = new ErrorViewModel { RequestId = requestId };
            return View(errorViewModel);
        }
    }
}
