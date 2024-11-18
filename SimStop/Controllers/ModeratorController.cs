using Microsoft.AspNetCore.Mvc;

namespace SimStop.Web.Controllers
{
    public class ModeratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Apply()
        {
            var model = 1;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Apply(int id)
        {
            var model = 1;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> StatisticsShops(int id)
        {
            var model = 1;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> StatisticsProducts(int id)
        {
            var model = 1;
            return View(model);
        }
    }
}
