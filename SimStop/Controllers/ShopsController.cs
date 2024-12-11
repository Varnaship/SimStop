using DeskMarket.Controllers;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ShopsController(ApplicationDbContext _context) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            var locations = await _context.Locations.ToListAsync();
            ViewBag.Locations = locations;

            var model = await _context.Shops
                .Include(s => s.Location)
                .Where(s => !s.IsDeleted)
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
        public async Task<IActionResult> Filter(int? locationId)
        {
            var userId = GetUserId();
            var query = _context.Shops
                .Include(s => s.Location)
                .Where(s => !s.IsDeleted)
                .AsQueryable();

            if (locationId.HasValue)
            {
                query = query.Where(s => s.LocationId == locationId);
            }

            var model = await query
                .Select(s => new ShopViewModel
                {
                    Id = s.Id,
                    ShopName = s.ShopName,
                    LocationName = s.Location.LocationName,
                    IsOwner = s.OwnerId == userId
                })
                .AsNoTracking()
                .ToListAsync();

            return PartialView("_ShopList", model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var shop = await _context.Shops
                .Include(s => s.Location)
                .Where(s => s.Id == id && !s.IsDeleted)
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
        [Authorize(Roles = "ShopAdmin,Admin")]
        public async Task<IActionResult> Create()
        {
            var model = new ShopCreateViewModel
            {
                Locations = await GetLocations()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "ShopAdmin,Admin")]
        public async Task<IActionResult> Create(ShopCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Locations = await GetLocations();
                return View(model);
            }

            // Check if a shop with the same name already exists
            var existingShop = await _context.Shops
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

            _context.Shops.Add(shop);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "ShopAdmin,Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var shop = await _context.Shops
                .Where(s => s.Id == id && !s.IsDeleted)
                .FirstOrDefaultAsync();

            if (shop == null || (shop.OwnerId != GetUserId() && !User.IsInRole("Admin")))
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
        [Authorize(Roles = "ShopAdmin,Admin")]
        public async Task<IActionResult> Edit(ShopEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Locations = await GetLocations();
                return View(model);
            }

            var shop = await _context.Shops
                .Where(s => s.Id == model.Id && !s.IsDeleted)
                .FirstOrDefaultAsync();

            if (shop == null || (shop.OwnerId != GetUserId() && !User.IsInRole("Admin")))
            {
                return Unauthorized();
            }

            shop.ShopName = model.ShopName;
            shop.LocationId = model.LocationId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "ShopAdmin,Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var shop = await _context.Shops
                .Where(s => s.Id == id && !s.IsDeleted)
                .FirstOrDefaultAsync();

            if (shop == null || (shop.OwnerId != GetUserId() && !User.IsInRole("Admin")))
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
        [Authorize(Roles = "ShopAdmin,Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shop = await _context.Shops
                .Where(s => s.Id == id && !s.IsDeleted)
                .Include(s => s.ShopProducts)
                .FirstOrDefaultAsync();

            if (shop == null || (shop.OwnerId != GetUserId() && !User.IsInRole("Admin")))
            {
                return Unauthorized();
            }

            shop.IsDeleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task<List<Location>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }
    }
}

