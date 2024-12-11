using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimStop.Models;
using System.Diagnostics;

namespace SimStop.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public new IActionResult StatusCode(int code)
        {
            if (code == 404)
            {
                return View("404");
            }
            else if (code == 500)
            {
                return View("500");
            }
            return View("Error");
        }
    }
}

