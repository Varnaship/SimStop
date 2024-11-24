using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimStop.Data;
using SimStop.Data.Models;
using SimStop.Web.Models;
using System.Globalization;

namespace SimStop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await context.Products
                .Where(p => !p.IsDeleted)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    ReleaseDate = p.ReleaseDate.ToString("d MMM yyyy", CultureInfo.InvariantCulture),
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Products
                .Where(p => !p.IsDeleted && p.Id == id)
                .Select(p => new ProductDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    ReleaseDate = p.ReleaseDate.ToString("d MMM yyyy", CultureInfo.InvariantCulture),
                    Weight = p.Weight,
                    BrandName = p.Brand.Name,
                    CategoryName = p.Category.CategoryName,
                    LocationName = p.Location.LocationName,
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await context.Products
                .Where(p => p.Id == id && !p.IsDeleted)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductEditViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                AddedOn = product.ReleaseDate.ToString("d MMM yyyy"),
                CategoryId = product.CategoryId,
                Categories = await GetCategories()
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            model.Categories = await GetCategories();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!DateTime.TryParseExact(model.AddedOn, "d MMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDateTime))
            {
                ModelState.AddModelError(nameof(model.AddedOn), "Invalid date or time format");
                return View(model);
            }

            var product = await context.Products.FindAsync(model.Id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.ReleaseDate = parsedDateTime;
            product.CategoryId = model.CategoryId;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }



        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var userId = GetUserId();

            var existingCartItem = await context.ProductsCustomers
                .FirstOrDefaultAsync(pc => pc.CustomerId == userId && pc.ProductId == id);

            if (existingCartItem == null)
            {
                var newProductClient = new ProductCustomer
                {
                    ProductId = id,
                    CustomerId = userId
                };

                await context.ProductsCustomers.AddAsync(newProductClient);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<List<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

        private string GetUserId()
        {
            // Replace with actual logic for getting user ID
            return User?.Identity?.Name ?? "anonymous-user-id";
        }
    }
}
