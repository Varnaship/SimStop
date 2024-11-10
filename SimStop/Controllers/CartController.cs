using Microsoft.AspNetCore.Mvc;

namespace SimStop.Web.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
