using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimStop.Data;
using SimStop.Web.Models.Product;
using SimStop.Web.Models.Shop;
using System.Linq;
using System.Threading.Tasks;
using static SimStop.Common.Constants.DatabaseConstants;

namespace SimStop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;

            var products = await _context.Products
                .Where(p => !p.IsDeleted)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    ReleaseDate = p.ReleaseDate.ToString(ProductReleaseDateFormat) // Format the date as string
                })
                .ToListAsync();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Filter(string name, int? categoryId, int? yearFrom, int? yearTo, decimal? minPrice, decimal? maxPrice)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }

            if (yearFrom.HasValue)
            {
                query = query.Where(p => p.ReleaseDate.Year >= yearFrom);
            }

            if (yearTo.HasValue)
            {
                query = query.Where(p => p.ReleaseDate.Year <= yearTo);
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice);
            }

            var products = await query
                .Where(p => !p.IsDeleted)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    ReleaseDate = p.ReleaseDate.ToString(ProductReleaseDateFormat) // Format the date as string
                })
                .ToListAsync();

            return PartialView("_ProductList", products);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products
                .Where(p => p.Id == id && !p.IsDeleted)
                .Select(p => new ProductDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    ReleaseDate = p.ReleaseDate.ToString(ProductReleaseDateFormat), // Format the date as string
                    Weight = p.Weight,
                    BrandName = p.Brand.Name,
                    CategoryName = p.Category.CategoryName,
                    LocationName = p.Location.LocationName
                })
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> ViewShops(int id)
        {
            var product = await _context.Products
                .Where(p => p.Id == id && !p.IsDeleted)
                .Select(p => new ProductShopsViewModel
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    Shops = p.ShopProducts.Select(sp => new ShopViewModel
                    {
                        Id = sp.ShopId,
                        ShopName = sp.Shop.ShopName,
                        LocationName = sp.Shop.Location.LocationName,
                        Price = sp.Discount > 0 ? sp.Product.Price * (1 - (decimal)sp.Discount / 100) : sp.Product.Price,
                        IsOwner = false // Adjust as needed
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products
                .Where(p => p.Id == id && !p.IsDeleted)
                .Select(p => new ProductEditViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    ReleaseDate = p.ReleaseDate, // Use DateTime directly
                    CategoryId = p.CategoryId,
                    Categories = _context.Categories.ToList() // Populate categories
                })
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _context.Categories.ToList(); // Repopulate categories
                return View(model);
            }

            var product = await _context.Products.FindAsync(model.Id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.ReleaseDate = model.ReleaseDate;
            product.CategoryId = model.CategoryId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products
                .Where(p => p.Id == id && !p.IsDeleted)
                .Select(p => new ProductDeleteViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.IsDeleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
