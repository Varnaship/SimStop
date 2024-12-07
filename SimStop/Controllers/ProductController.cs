using DeskMarket.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimStop.Data;
using SimStop.Data.Models;
using SimStop.Web.Models.Product;
using System.Globalization;

namespace SimStop.Web.Controllers
{
    public class ProductController(ApplicationDbContext context) : BaseController
    {


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
            try
            {
                var userId = GetUserId();

                // Check if the product exists
                var productExists = await context.Products
                    .AnyAsync(p => p.Id == id && !p.IsDeleted);

                if (!productExists)
                {
                    return NotFound("Product does not exist.");
                }

                // Check if the product is already in the cart
                var existingCartItem = await context.ProductsCustomers
                    .FirstOrDefaultAsync(pc => pc.CustomerId == userId && pc.ProductId == id);

                if (existingCartItem == null)
                {
                    // Add the product to the cart
                    var newProductClient = new ProductCustomer
                    {
                        ProductId = id,
                        CustomerId = userId
                    };

                    await context.ProductsCustomers.AddAsync(newProductClient);
                    await context.SaveChangesAsync();
                }

                return Json(new { success = true, message = "Product added to cart." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product to cart: {ex.Message}");
                return StatusCode(500, "An error occurred while adding the product to the cart.");
            }
        }




        private async Task<List<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

    }
}
