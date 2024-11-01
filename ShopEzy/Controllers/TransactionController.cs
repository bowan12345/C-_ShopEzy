using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopEzy.Data;
using ShopEzy.Models;
using ShopEzy.utils;

namespace ShopEzy.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ShopEzyDbContext _context;

        public TransactionController(ShopEzyDbContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            var customer = HttpContext.Session.GetObject<Customer>("customer");
            if (customer == null)
            {
                TempData["ErrorMessage"] = "You have not Login!";
                return RedirectToAction("Login", "Customer");
            }
            var transactions = await _context.Transaction
                 .Where(t => t.CustomerId == customer.Id)
                 .ToListAsync();

            if (!transactions.Any())
            {
                TempData["ErrorMessage"] = "You have not Purchase Anything!";
                return RedirectToAction("Index", "Product");
            }
            // Retrieve the customer from the session
            ViewBag.Customer = HttpContext.Session.GetObject<Customer>("customer");
            return View(transactions);
        }




        // POST: Transaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(string name,decimal price, int Id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            //get customer info 
            var customer = HttpContext.Session.GetObject<Customer>("customer");
            if (customer == null) 
            {
                TempData["ErrorMessage"] = "You have not Login!";
                ModelState.AddModelError("", "You have not Login!");
                return RedirectToAction("Login", "Customer");
            }
            //create a new transaction object
            Transaction transaction = new Transaction();
            transaction.CustomerId = customer.Id;
            transaction.ProductId = Id;
            transaction.ProductName = name;
            transaction.Quantity = 1;
            transaction.Price = price;
            transaction.Date = DateTime.Now;
            // add a new record into database
            _context.Add(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            //get customer info 
            var customer = HttpContext.Session.GetObject<Customer>("customer");
            if (customer == null)
            {
                TempData["ErrorMessage"] = "You have not Login!";
                ModelState.AddModelError("", "You have not Login!");
                return RedirectToAction("Login", "Customer");
            }
            var transaction = await _context.Transaction
                .FirstOrDefaultAsync(t => t.Id == id && t.CustomerId == customer.Id);
            if (transaction != null)
            {
                _context.Transaction.Remove(transaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
