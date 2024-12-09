using DeskMarket.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimStop.Data;
using SimStop.Data.Models;
using SimStop.Web.ViewModels;

namespace SimStop.Web.Controllers
{
    public class CartController(ApplicationDbContext _context) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();

            var cartItems = await _context.ShopsCustomers
                .Where(pc => pc.CustomerId == userId)
                .Include(pc => pc.Product)
                    .ThenInclude(p => p.ShopProducts)
                .ToListAsync();

            var cartViewModel = new CartViewModel
            {
                Items = cartItems.Select(pc => new CartItemViewModel
                {
                    Id = pc.Product.Id,
                    ProductName = pc.Product.Name,
                    ImageUrl = "/images/products/default.jpg", // Replace with your logic for image paths
                    Price = CalculateDiscountedPrice(pc.Product, pc.ShopId),
                    Quantity = 1 // Assuming 1 item per product for simplicity
                }).ToList(),
                TotalValue = cartItems.Sum(pc => CalculateDiscountedPrice(pc.Product, pc.ShopId))
            };

            return View(cartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var userId = GetUserId();

            var productCustomer = await _context.ShopsCustomers
                .FirstOrDefaultAsync(pc => pc.CustomerId == userId && pc.ProductId == id);

            if (productCustomer != null)
            {
                _context.ShopsCustomers.Remove(productCustomer);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var userId = GetUserId();

            // Fetch cart items for the user
            var cartItems = await _context.ShopsCustomers
                .Where(pc => pc.CustomerId == userId)
                .Include(pc => pc.Product)
                    .ThenInclude(p => p.ShopProducts)
                .ToListAsync();

            if (!cartItems.Any())
            {
                TempData["ErrorMessage"] = "Your cart is empty!";
                return RedirectToAction("Index");
            }

            decimal totalValue = 0;

            foreach (var item in cartItems)
            {
                var product = item.Product;

                // Accumulate total cart value
                var discountedPrice = CalculateDiscountedPrice(product, item.ShopId);
                totalValue += discountedPrice;

                // Allocate income to the shop owner
                var shop = await _context.Shops.FirstOrDefaultAsync(s => s.Id == item.ShopId);
                if (shop != null)
                {
                    shop.TotalRevenue += discountedPrice;
                }
            }

            // Save income allocation to database
            await _context.SaveChangesAsync();

            // Clear the cart for the user
            _context.ShopsCustomers.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            // Pass totalValue to the confirmation view
            TempData["TotalValue"] = totalValue.ToString("C");

            return RedirectToAction("Confirmation");
        }

        [HttpGet]
        public IActionResult Confirmation()
        {
            ViewBag.TotalValue = TempData["TotalValue"] ?? "0.00";
            return View();
        }

        private static decimal CalculateDiscountedPrice(Product product, int shopId)
        {
            var shopProduct = product.ShopProducts.FirstOrDefault(sp => sp.ShopId == shopId);
            if (shopProduct != null)
            {
                var discount = shopProduct.Discount;
                return product.Price * (1 - (decimal)discount / 100);
            }

            return product.Price;
        }
    }
}
