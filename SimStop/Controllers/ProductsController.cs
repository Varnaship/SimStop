﻿using DeskMarket.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimStop.Data;
using SimStop.Web.Models;
using SimStop.Web.Models.Configuration;

namespace SimStop.Web.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly ApplicationDbContext context;

        public ProductsController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();

            var model = await context.Products
                .Where(p => p.IsDeleted != true)
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    BrandId = p.BrandId,
                    Description = p.Description,
                    ReleaseDate = p.ReleaseDate.ToString()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Products
                .Where(g => g.IsDeleted != true && g.Id == id)
                .Select(g => new ProductDetailsViewModel()
                {
                    
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}