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
        public IActionResult Checkout()
        {
            // Placeholder for payment/checkout logic
            TempData["Message"] = "Checkout completed successfully. Thank you for your purchase!";
            return RedirectToAction(nameof(Index));
        }

    }
}
