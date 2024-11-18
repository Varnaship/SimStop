using Microsoft.AspNetCore.Mvc;

namespace SimStop.Web.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var model = 1;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteFromCart(int id)
        {
            var model = 1;
            return View(model);
        }
    }
}
