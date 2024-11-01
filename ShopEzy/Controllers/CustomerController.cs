using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using ShopEzy.Data;
using ShopEzy.Models;
using ShopEzy.utils;
using System.Net;

namespace ShopEzy.Controllers
{
    public class CustomerController : Controller
    {

        private ShopEzyDbContext _dbContext;

        public CustomerController(ShopEzyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Get all customers from database
            //var customers = _dbContext.Customer.ToList();

            // Pass the customers to the view
            //return View(customers);
            // Retrieve the customer from the session
            var customer = HttpContext.Session.GetObject<Customer>("customer");
           if (customer == null)
            {
               
                ModelState.AddModelError("", "Invalid User.");
                return View();
            }

            ViewBag.Customer = customer;
            return View(customer);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string firstname, string lastname, string email, string phonenumber, DateTime dateofbirth, string address, string password, string confirmPassword)
        {
            //validate fields
            if (string.IsNullOrEmpty(firstname))
            {
                ModelState.AddModelError("firstname", "First name is required.");
            }
            if (string.IsNullOrEmpty(lastname))
            {
                ModelState.AddModelError("lastname", "Last name is required.");
            }
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("email", "Email is required.");
            }
            if (string.IsNullOrEmpty(phonenumber))
            {
                ModelState.AddModelError("phonenumber", "Phone number is required.");
            }
            if (string.IsNullOrEmpty(address))
            {
                ModelState.AddModelError("address", "Address is required.");
            }
            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "Password is required.");
            }
            if (string.IsNullOrEmpty(confirmPassword))
            {
                ModelState.AddModelError("confirmPassword", "Confirm password is required.");
            }

            // match passwords
            if (password != confirmPassword)
            {
                ModelState.AddModelError("confirmPassword", "The password and confirmation password do not match.");
            }

            // query customer from database by email
            var customer = _dbContext.Customer.FirstOrDefault(c => c.Email == email);

            if (customer != null)
            {
                ModelState.AddModelError("", " Email Alredy Exists.");
                return View();
            }


            // if modelstate is not valid ,return and show the error message
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please correct the errors.");
                return View();
            }

            // save user 
            CreateCustomer(firstname, lastname, email, phonenumber, dateofbirth, address, password);

            // set success message
            TempData["SuccessMessage"] = "Registration successful!";

            return RedirectToAction("Login");
        }

        public int CreateCustomer(string firstname, string lastname, string email, string phonenumber, DateTime dateofbirth, string address, string password)
        {
            _dbContext.Customer.Add(new Customer()
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                PhoneNumber = phonenumber,
                DateOfBirth = dateofbirth,
                Address = address,
                Password = password
            });
            int result = _dbContext.SaveChanges();

            return result;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // query customer from database
            var customer = _dbContext.Customer.FirstOrDefault(c => c.Email == email && c.Password == password);

            if (customer == null)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View();
            }

            // save user info 
            HttpContext.Session.SetObject("customer", customer);
           

            // redirect to home page
            return RedirectToAction("Index","Product");

        }


        [HttpPost]
        public IActionResult Update(Customer customer) 
        {
            //validate fields
            if (string.IsNullOrEmpty(customer.FirstName))
            {
                ModelState.AddModelError("firstname", "First name is required.");
            }
            if (string.IsNullOrEmpty(customer.LastName))
            {
                ModelState.AddModelError("lastname", "Last name is required.");
            }
            if (string.IsNullOrEmpty(customer.Email))
            {
                ModelState.AddModelError("email", "Email is required.");
            }
            if (string.IsNullOrEmpty(customer.PhoneNumber))
            {
                ModelState.AddModelError("phonenumber", "Phone number is required.");
            }
            if (string.IsNullOrEmpty(customer.Address))
            {
                ModelState.AddModelError("address", "Address is required.");
            }
            if (string.IsNullOrEmpty(customer.Password))
            {
                ModelState.AddModelError("password", "Password is required.");
            }

            // if modelstate is not valid ,return and show the error message
            if (!ModelState.IsValid)
            {

                ModelState.AddModelError("", "Please correct the errors.");
                return View();
                
            }

            // update by email
            var existingCustomer = _dbContext.Customer.FirstOrDefault(c => c.Email == customer.Email);
            if (existingCustomer == null)
            {
                // customer not found 
                ModelState.AddModelError("", "Customer not found.");
                return View();
            }

            // Update only the properties that are allowed to be modified
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.DateOfBirth = customer.DateOfBirth;
            existingCustomer.Address = customer.Address;
            existingCustomer.Password = customer.Password;
            _dbContext.Entry(existingCustomer).State = EntityState.Modified;
            _dbContext.SaveChanges();

            // set success message
            TempData["SuccessMessage"] = "Profile updated!";
            //save user info into session
            var updatedCustomer = _dbContext.Customer.FirstOrDefault(c => c.Email == customer.Email);
            HttpContext.Session.SetObject("customer", updatedCustomer);
            // Redirect to home page
            return RedirectToAction("Index", "Customer");
        }
    }
}
