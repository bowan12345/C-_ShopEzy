using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopEzy.Data;
using ShopEzy.Models;
using ShopEzy.utils;

namespace ShopEzy.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopEzyDbContext _context;

        // Constructor to inject the database context
        public ProductController(ShopEzyDbContext context)
        {
            _context = context;
        }

        // GET: Product
        /*public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }*/

        // GET: Product with sorting and searching
        public IActionResult Index(string sortOrder, string SearchName)
        {
            // Set the sort parameters for the view
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["CurrentFilter"] = SearchName;

            // Query all products
            var products = from p in _context.Product select p;

            // Apply search filter if provided
            if (!string.IsNullOrEmpty(SearchName))
            {
                products = products.Where(p => p.Name != null && p.Name.Contains(SearchName));
            }

            // Apply sorting based on the sortOrder parameter
            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "Price":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products = products.OrderBy(p => p.Name);
                    break;
            }

            // Retrieve the customer from the session
            ViewBag.Customer = HttpContext.Session.GetObject<Customer>("customer");

            // Return the view with the filtered and sorted products
            return View(products.ToList());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // Return NotFound if id is null
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the product by id
            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);

            // Return NotFound if product is not found
            if (product == null)
            {
                return NotFound();
            }

            // Retrieve the customer from the session
            ViewBag.Customer = HttpContext.Session.GetObject<Customer>("customer");

            // Return the view with the product details
            return View(product);
        }
    }
}
