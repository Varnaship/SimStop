using Microsoft.AspNetCore.Mvc;

namespace SimStop.Web.Controllers
{
    public class ShopsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
