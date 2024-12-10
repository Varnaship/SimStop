using DeskMarket.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimStop.Data;
using SimStop.Data.Models;
using SimStop.Web.Models.Product;
using System.Globalization;
using static SimStop.Common.Constants.DatabaseConstants;

namespace SimStop.Web.Controllers
{
    public class ShopProductsController(ApplicationDbContext context) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index(int shopId)
        {
            var shop = await context.Shops
                .Include(s => s.ShopProducts)
                    .ThenInclude(sp => sp.Product)
                        .ThenInclude(p => p.Brand)
                .Include(s => s.ShopProducts)
                    .ThenInclude(sp => sp.Product)
                        .ThenInclude(p => p.Category)
                .Where(s => s.Id == shopId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (shop == null)
            {
                return NotFound();
            }

            var categories = await context.Categories.ToListAsync();
            ViewBag.Categories = categories;

            var userId = GetUserId();
            var isOwner = shop.OwnerId == userId;

            var products = shop.ShopProducts.Select(sp => new ProductViewModel
            {
                Id = sp.Product.Id,
                Name = sp.Product.Name,
                Price = sp.Product.Price,
                DiscountedPrice = sp.Discount > 0 ? sp.Product.Price * (1 - (decimal)sp.Discount / 100) : (decimal?)null,
                Description = sp.Product.Description,
                ReleaseDate = sp.Product.ReleaseDate.ToString(ProductReleaseDateFormat, CultureInfo.InvariantCulture),
                BrandName = sp.Product.Brand.Name,
                CategoryName = sp.Product.Category.CategoryName
            }).ToList();

            var model = new ShopProductsViewModel
            {
                ShopId = shop.Id,
                ShopName = shop.ShopName,
                IsOwner = isOwner,
                Products = products
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Filter(int shopId, string name, int? categoryId, int? yearFrom, int? yearTo, decimal? minPrice, decimal? maxPrice, bool? hasDiscount)
        {
            var query = context.ShopsProducts
                .Include(sp => sp.Product)
                .Where(sp => sp.ShopId == shopId)
                .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(sp => sp.Product.Name.Contains(name));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(sp => sp.Product.CategoryId == categoryId);
            }

            if (yearFrom.HasValue)
            {
                query = query.Where(sp => sp.Product.ReleaseDate.Year >= yearFrom);
            }

            if (yearTo.HasValue)
            {
                query = query.Where(sp => sp.Product.ReleaseDate.Year <= yearTo);
            }

            if (minPrice.HasValue)
            {
                query = query.Where(sp => sp.Product.Price >= minPrice);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(sp => sp.Product.Price <= maxPrice);
            }

            if (hasDiscount.HasValue && hasDiscount.Value)
            {
                query = query.Where(sp => sp.Discount > 0);
            }

            var products = await query
                .Select(sp => new ProductViewModel
                {
                    Id = sp.Product.Id,
                    Name = sp.Product.Name,
                    Price = sp.Product.Price,
                    DiscountedPrice = sp.Discount > 0 ? sp.Product.Price * (1 - (decimal)sp.Discount / 100) : (decimal?)null,
                    Description = sp.Product.Description,
                    ReleaseDate = sp.Product.ReleaseDate.ToString(ProductReleaseDateFormat, CultureInfo.InvariantCulture),
                    BrandName = sp.Product.Brand.Name,
                    CategoryName = sp.Product.Category.CategoryName
                })
                .ToListAsync();

            var shop = await context.Shops
                .Where(s => s.Id == shopId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (shop == null)
            {
                return NotFound();
            }

            var userId = GetUserId();
            var isOwner = shop.OwnerId == userId;

            var model = new ShopProductsViewModel
            {
                ShopId = shop.Id,
                ShopName = shop.ShopName,
                IsOwner = isOwner,
                Products = products
            };

            return PartialView("_ProductList", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int shopId)
        {
            var userId = GetUserId();
            var product = await context.Products
                .Include(p => p.ShopProducts)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == productId && !p.IsDeleted);

            if (product == null)
            {
                return Json(new { success = false, message = "Product does not exist." });
            }

            var shopProduct = await context.ShopsProducts
                .Include(sp => sp.Shop)
                .FirstOrDefaultAsync(sp => sp.ProductId == productId && sp.ShopId == shopId);

            if (shopProduct == null)
            {
                return Json(new { success = false, message = "Product is not available in the specified shop." });
            }

            if (shopProduct.Shop.OwnerId == userId)
            {
                return Json(new { success = false, message = "Owners cannot buy their own products." });
            }

            var existingCartItem = await context.ShopsCustomers
                .FirstOrDefaultAsync(pc => pc.CustomerId == userId && pc.ProductId == productId);

            if (existingCartItem != null)
            {
                return Json(new { success = false, message = "Product is already in the cart." });
            }

            try
            {
                var newProductClient = new ShopCustomer
                {
                    ProductId = productId,
                    CustomerId = userId,
                    ShopId = shopId
                };

                await context.ShopsCustomers.AddAsync(newProductClient);
                await context.SaveChangesAsync();

                var discount = shopProduct.Discount;
                var discountedPrice = product.Price * (1 - (decimal)discount / 100);

                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = discountedPrice,
                    Description = product.Description,
                    ReleaseDate = product.ReleaseDate.ToString(ProductReleaseDateFormat, CultureInfo.InvariantCulture),
                    BrandName = product.Brand?.Name ?? "Unknown Brand",
                    CategoryName = product.Category?.CategoryName ?? "Unknown Category"
                };

                return Json(new { success = true, product = productViewModel });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred while adding the product to the cart: {ex.Message}" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct(int shopId)
        {
            var userId = GetUserId();
            var shop = await context.Shops.FindAsync(shopId);

            if (shop == null || shop.OwnerId != userId)
            {
                return Unauthorized();
            }

            var model = new AddProductViewModel
            {
                ShopId = shopId,
                ShopName = shop.ShopName,
                Products = await context.Products
                    .Where(p => !p.IsDeleted)
                    .Select(p => new ProductViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Description = p.Description,
                        ReleaseDate = p.ReleaseDate.ToString(ProductReleaseDateFormat, CultureInfo.InvariantCulture),
                        BrandName = p.Brand.Name,
                        CategoryName = p.Category.CategoryName
                    }).ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(AddProductViewModel model)
        {
            var userId = GetUserId();
            var shop = await context.Shops
                .Include(s => s.ShopProducts)
                .FirstOrDefaultAsync(s => s.Id == model.ShopId);

            if (shop == null || shop.OwnerId != userId)
            {
                return Unauthorized();
            }

            var product = await context.Products.FindAsync(model.ProductId);

            if (product == null || product.IsDeleted)
            {
                return NotFound("Product does not exist.");
            }

            var existingShopProduct = shop.ShopProducts.FirstOrDefault(sp => sp.ProductId == model.ProductId);

            if (existingShopProduct != null)
            {
                ViewBag.ErrorMessage = "Product already exists in the shop.";
                model.Products = await context.Products
                    .Where(p => !p.IsDeleted)
                    .Select(p => new ProductViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Description = p.Description,
                        ReleaseDate = p.ReleaseDate.ToString(ProductReleaseDateFormat, CultureInfo.InvariantCulture),
                        BrandName = p.Brand.Name,
                        CategoryName = p.Category.CategoryName
                    }).ToListAsync();
                return View(model);
            }

            var shopProduct = new ShopProduct
            {
                ShopId = model.ShopId,
                ProductId = model.ProductId,
                Discount = 0 // Default discount
            };

            context.ShopsProducts.Add(shopProduct);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { shopId = model.ShopId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveProduct(int shopId, int productId)
        {
            var userId = GetUserId();
            var shop = await context.Shops
                .Include(s => s.ShopProducts)
                .FirstOrDefaultAsync(s => s.Id == shopId);

            if (shop == null || shop.OwnerId != userId)
            {
                return Unauthorized();
            }

            var shopProduct = shop.ShopProducts.FirstOrDefault(sp => sp.ProductId == productId);

            if (shopProduct == null)
            {
                return NotFound("Product does not exist in the shop.");
            }

            context.ShopsProducts.Remove(shopProduct);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { shopId = shopId });
        }

        [HttpGet]
        public async Task<IActionResult> ApplyDiscount(int shopId, int productId)
        {
            var userId = GetUserId();
            var shop = await context.Shops.FindAsync(shopId);

            if (shop == null || shop.OwnerId != userId)
            {
                return Unauthorized();
            }

            var product = await context.Products.FindAsync(productId);

            if (product == null || product.IsDeleted)
            {
                return NotFound("Product does not exist.");
            }

            var existingDiscount = await context.ShopsProducts
                .FirstOrDefaultAsync(d => d.ShopId == shopId && d.ProductId == productId);

            var model = new ApplyDiscountViewModel
            {
                ShopId = shopId,
                ProductId = productId,
                ProductName = product.Name,
                Discount = existingDiscount?.Discount ?? 0
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplyDiscount(ApplyDiscountViewModel model)
        {
            var userId = GetUserId();
            var shop = await context.Shops.FindAsync(model.ShopId);

            if (shop == null || shop.OwnerId != userId)
            {
                return Unauthorized();
            }

            var product = await context.Products.FindAsync(model.ProductId);

            if (product == null || product.IsDeleted)
            {
                return NotFound("Product does not exist.");
            }

            var existingDiscount = await context.ShopsProducts
                .FirstOrDefaultAsync(d => d.ShopId == model.ShopId && d.ProductId == model.ProductId);

            if (existingDiscount != null)
            {
                existingDiscount.Discount = model.Discount;
            }
            else
            {
                var discount = new ShopProduct
                {
                    ShopId = model.ShopId,
                    ProductId = model.ProductId,
                    Discount = model.Discount
                };
                context.ShopsProducts.Add(discount);
            }

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { shopId = model.ShopId });
        }
    }
}

