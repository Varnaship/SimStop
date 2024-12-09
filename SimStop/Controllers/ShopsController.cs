using DeskMarket.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimStop.Data;
using SimStop.Data.Models;
using SimStop.Web.Models.Shop;
using System.Globalization;
using System.Security.Claims;
using static SimStop.Common.Constants.DatabaseConstants;

namespace SimStop.Web.Controllers
{
    public class ShopsController(ApplicationDbContext context) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            var model = await context.Shops
                .Include(s => s.Location)
                .Select(s => new ShopViewModel
                {
                    Id = s.Id,
                    ShopName = s.ShopName,
                    LocationName = s.Location.LocationName,
                    IsOwner = s.OwnerId == userId
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var shop = await context.Shops
                .Include(s => s.Location)
                .Where(s => s.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (shop == null)
            {
                return NotFound();
            }

            var userId = GetUserId();
            var isOwner = shop.OwnerId == userId;

            var model = new ShopDetailsViewModel
            {
                Id = shop.Id,
                ShopName = shop.ShopName,
                LocationName = shop.Location.LocationName,
                TotalRevenue = isOwner ? shop.TotalRevenue : (decimal?)null,
                IsOwner = isOwner
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ShopCreateViewModel
            {
                Locations = await GetLocations()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShopCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Locations = await GetLocations();
                return View(model);
            }

            // Check if a shop with the same name already exists
            var existingShop = await context.Shops
                .FirstOrDefaultAsync(s => s.ShopName == model.ShopName);

            if (existingShop != null)
            {
                ModelState.AddModelError(string.Empty, "A shop with the same name already exists.");
                model.Locations = await GetLocations();
                return View(model);
            }

            var shop = new Shop
            {
                ShopName = model.ShopName,
                LocationId = model.LocationId,
                TotalRevenue = 0, // Set TotalRevenue to 0 when creating a new shop
                OwnerId = GetUserId() // Set the owner of the shop
            };

            context.Shops.Add(shop);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var shop = await context.Shops.FindAsync(id);

            if (shop == null || shop.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new ShopEditViewModel
            {
                Id = shop.Id,
                ShopName = shop.ShopName,
                LocationId = shop.LocationId,
                Locations = await GetLocations()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ShopEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Locations = await GetLocations();
                return View(model);
            }

            var shop = await context.Shops.FindAsync(model.Id);

            if (shop == null || shop.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            shop.ShopName = model.ShopName;
            shop.LocationId = model.LocationId;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var shop = await context.Shops.FindAsync(id);

            if (shop == null || shop.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new ShopDeleteViewModel
            {
                Id = shop.Id,
                ShopName = shop.ShopName
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shop = await context.Shops
                .Include(s => s.ShopProducts)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (shop == null || shop.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            context.Shops.Remove(shop);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task<List<Location>> GetLocations()
        {
            return await context.Locations.ToListAsync();
        }
    }
}
