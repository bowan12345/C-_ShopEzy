using Microsoft.AspNetCore.Mvc;
using ShopEzy.Models;

namespace ShopEzy.Controllers
{
    public class ProductUnitTestController : Controller
    {

        public List<Product> GetProductList() 
        {
            List<Product> productList = new List<Product>();
            Product product1 = new Product();
            product1.Id = 1;
            product1.Name = "Product 1";
            product1.Price = 500;
            product1.Description = "This is a test product 1";
            productList.Add(product1);
            Product product2 = new Product();
            product2.Id = 2;
            product2.Name = "Product 2";
            product2.Price = 100;
            product2.Description = "This is a test product 2";
            productList.Add(product2);
            Product product3 = new Product();
            product3.Id = 3;
            product3.Name = "Product 3";
            product3.Price = 400;
            product3.Description = "This is a test product 3";
            productList.Add(product3);  
            Product product4 = new Product();
            product4.Id = 4;
            product4.Name = "Product 4";
            product4.Price = 800;
            product4.Description = "This is a test product 4";
            productList.Add(product4);
            return productList;
        }

        public IActionResult Index()
        {
            List<Product> productList = GetProductList();
            return View(productList);
        }

        public IActionResult Details(int id)
        {
            var product = GetProductList().FirstOrDefault(p => p.Id == id);

            return View(product);
        }


        public IActionResult SearchName()
        {
            List<Product> productList = GetProductList();
            var result = productList.Where(p => p.Name != null && p.Name.Contains("1"));

            return View("Index", result);
        }

        public IActionResult SortByName()
        {
            List<Product> productList = GetProductList();
            var result = productList.OrderByDescending(p => p.Name);

            return View("Index", result);
        }

        public IActionResult SortByPrice()
        {
            List<Product> productList = GetProductList();
            var result = productList.OrderByDescending(p => p.Price);

            return View("Index", result);
        }


    }
}
