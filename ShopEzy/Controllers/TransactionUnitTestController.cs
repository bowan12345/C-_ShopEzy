using Microsoft.AspNetCore.Mvc;
using ShopEzy.Models;

namespace ShopEzy.Controllers
{
    public class TransactionUnitTestController : Controller
    {
        private static List<Transaction> transactions = [];

        public TransactionUnitTestController() 
        {
            if (transactions.Count == 0)
            {
                Transaction transaction1 = new Transaction
                {
                    Id = 1,
                    CustomerId = 1,
                    ProductId = 1000,
                    ProductName = "Product 1",
                    Quantity = 10,
                    Date = DateTime.Now
                };
                transactions.Add(transaction1);
                Transaction transaction2 = new Transaction
                {
                    Id = 2,
                    CustomerId = 2,
                    ProductId = 2000,
                    ProductName = "Product 2",
                    Quantity = 20,
                    Date = DateTime.Now
                };
                transactions.Add(transaction2);
                Transaction transaction3 = new Transaction
                {
                    Id = 3,
                    CustomerId = 3,
                    ProductId = 3000,
                    ProductName = "Product 3",
                    Quantity = 30,
                    Date = DateTime.Now
                };
                transactions.Add(transaction3);
            }

        }

        public IActionResult Index()
        {
            return View(transactions);
        }

        public IActionResult Create()
        {
            Random random = new();
            Transaction transaction = new Transaction
            {
                Id = random.Next(1, 1000),
                CustomerId = random.Next(1, 1000),
                ProductId = random.Next(100, 5000),
                ProductName = "Product"+ random.Next(1, 1000),
                Quantity = random.Next(1, 20),
                Date = DateTime.Now
            };
            transactions.Add(transaction);
            return View("Index", transactions);
        }


        public IActionResult Delete(int id)
        {
            var transaction = transactions.FirstOrDefault(p => p.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }
            transactions.Remove(transaction);

            return View("Index",transactions);
        }
    }
}
