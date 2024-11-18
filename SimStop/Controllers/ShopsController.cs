using Microsoft.AspNetCore.Mvc;

namespace SimStop.Web.Controllers
{
    public class ShopsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var model = 1;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            var model = 1;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = 1;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            var model = 1;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            var model = 1;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var model = 1;
            return View(model);
        }
    }
}
