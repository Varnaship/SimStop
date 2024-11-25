using DeskMarket.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimStop.Data;
using SimStop.Web.ViewModels;

namespace SimStop.Web.Controllers
{
    public class CartController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();

            var cartItems = await _context.ProductsCustomers
                .Where(pc => pc.CustomerId == userId)
                .Include(pc => pc.Product)
                .Select(pc => new CartItemViewModel
                {
                    Id = pc.Product.Id,
                    ProductName = pc.Product.Name,
                    ImageUrl = "/images/products/default.jpg", // Replace with your logic for image paths
                    Price = pc.Product.Price,
                    Quantity = 1 // Assuming 1 item per product for simplicity
                })
                .ToListAsync();

            var cartViewModel = new CartViewModel
            {
                Items = cartItems,
                TotalValue = cartItems.Sum(item => item.Price * item.Quantity)
            };

            return View(cartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var userId = GetUserId();

            var productCustomer = await _context.ProductsCustomers
                .FirstOrDefaultAsync(pc => pc.CustomerId == userId && pc.ProductId == id);

            if (productCustomer != null)
            {
                _context.ProductsCustomers.Remove(productCustomer);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var userId = GetUserId();

            // Fetch cart items for the user
            var cartItems = await _context.ProductsCustomers
                .Where(pc => pc.CustomerId == userId)
                .Include(pc => pc.Product)
                .ThenInclude(p => p.Brand) // Assuming Brand has a Shop
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
                totalValue += product.Price;

                // Allocate income to the shop's moderator (owner)
                var shopOwnerId = product.Brand.ModeratorId; // Assuming Brand has a ModeratorId
                var moderator = await _context.Moderators.FindAsync(shopOwnerId);

                if (moderator != null)
                {
                    moderator.Income += product.Price;
                }
            }

            // Save income allocation to database
            await _context.SaveChangesAsync();

            // Clear the cart for the user
            _context.ProductsCustomers.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            // Pass totalValue to the confirmation view
            TempData["TotalValue"] = totalValue.ToString("C");

            return RedirectToAction("Confirmation");
        }

    }
}
