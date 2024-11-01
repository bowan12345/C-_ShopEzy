using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Moq;
using NuGet.ContentModel;
using ShopEzy.Data;
using ShopEzy.Models;
using ShopEzy.utils;
using System.Net;
using Xunit;

namespace ShopEzy.Controllers
{
    public class CustomerUnitTestController : Controller
    {

        private static List<Customer> customerList = [];   

        public CustomerUnitTestController()
        {
            if (customerList.Count == 0) 
            {
                //create a list of customers
                customerList.Add(new Customer(1, "John", "Doe", "test1@email.com", "1234567890", DateTime.Now, "street", "1234567890"));
                customerList.Add(new Customer(2, "Jane", "Doe", "test2@email.com", "1234567890", DateTime.Now, "street", "1234567890"));
                customerList.Add(new Customer(3, "Bob", "Smith", "test3@email.com", "1234567890", DateTime.Now, "street", "1234567890"));
                customerList.Add(new Customer(4, "Alice", "Johnson", "test4@email.com", "1234567890", DateTime.Now, "street", "1234567890"));
            }
        }

        public IActionResult Index()
        {
            return View(customerList);
        }

        public IActionResult Login()
        {
            
            //get customer info
            var customer = customerList.FirstOrDefault();
            return View(customer);


        }

        public IActionResult Register()
        {
            //create a new customer
            Random random = new();
            Customer customer = new Customer();
            customer.Id = random.Next(1, 1000);
            customer.FirstName = "John"+ random.Next(1, 100);
            customer.LastName = "Doe" + random.Next(1, 100);
            customer.Email = "test" + random.Next(50, 100)+"@email.com";
            customer.PhoneNumber = "1234567890";
            customer.DateOfBirth = DateTime.Now;
            customer.Address = "street" + random.Next(1, 100);
            customer.Password = "1234567890";

            customerList.Add(customer);
            return View("Index", customerList);
        }


        [HttpGet]
        public IActionResult Update()
        {
            var customer = customerList.FirstOrDefault();
            return View(customer);

        }


        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            var macthCustomer = customerList.FirstOrDefault(c => c.Id == customer.Id);
            if (macthCustomer == null)
            {
                return NotFound();
            }
            macthCustomer.FirstName = customer.FirstName;
            macthCustomer.LastName = customer.LastName;
            macthCustomer.PhoneNumber = customer.PhoneNumber;
            macthCustomer.DateOfBirth = customer.DateOfBirth;
            macthCustomer.Address = customer.Address;
            macthCustomer.Password = customer.Password;
            return View();

        }
    }
}
