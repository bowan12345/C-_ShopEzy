using Microsoft.AspNetCore.Mvc;
using ShopEzy.Controllers;
using ShopEzy.Models;

namespace ShopEzyUnitTestProject
{
    [TestClass]
    public class CustomerUnitTest
    {
        [TestMethod]
        public void TestIndexMethod()
        {
            CustomerUnitTestController customerUnitTestController = new CustomerUnitTestController();
            IActionResult result = customerUnitTestController.Index() as IActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestLoginMethod()
        {
            CustomerUnitTestController customerUnitTestController = new CustomerUnitTestController();
            IActionResult result = customerUnitTestController.Login() as IActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestRegisterMethod()
        {
            CustomerUnitTestController customerUnitTestController = new CustomerUnitTestController();
            IActionResult result = customerUnitTestController.Register() as IActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestUpdateMethod()
        {
            CustomerUnitTestController customerUnitTestController = new CustomerUnitTestController();
            Customer customer = new Customer();
            customer.Id = 2;
            customer.FirstName = "DDL";
            customer.LastName = "DDL";
            customer.Email = "DDL@gmail.com";
            customer.Password = "123";
            customer.PhoneNumber = "1234567890";
            customer.Address = "123 Main St";
            IActionResult result = customerUnitTestController.Update(customer) as IActionResult;
            Assert.IsNotNull(result);
        }


    }//end of customer controller test class


    [TestClass]
    public class ProductUnitTest
    {
        [TestMethod]
        public void TestIndexMethod()
        {
            ProductUnitTestController productUnitTestController = new ProductUnitTestController();
            IActionResult result = productUnitTestController.Index() as IActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDetailsMethod()
        {
            ProductUnitTestController productUnitTestController = new ProductUnitTestController();
            IActionResult result = productUnitTestController.Details(1) as IActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestSearchMethod()
        {
            ProductUnitTestController productUnitTestController = new ProductUnitTestController();
            IActionResult result = productUnitTestController.SearchName() as IActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestSortByNameMethod()
        {
            ProductUnitTestController productUnitTestController = new ProductUnitTestController();
            IActionResult result = productUnitTestController.SortByName() as IActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestSortByPriceMethod()
        {
            ProductUnitTestController productUnitTestController = new ProductUnitTestController();
            IActionResult result = productUnitTestController.SortByPrice() as IActionResult;
            Assert.IsNotNull(result);
        }



    }//end of product controller test class


    [TestClass]
    public class TransactionUnitTest
    {
        [TestMethod]
        public void TestIndexMethod()
        {
            TransactionUnitTestController transactionUnitTestController = new TransactionUnitTestController();
            IActionResult result = transactionUnitTestController.Index() as IActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCreateMethod()
        {
            TransactionUnitTestController transactionUnitTestController = new TransactionUnitTestController();
            IActionResult result = transactionUnitTestController.Create() as IActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDeleteMethod()
        {
            TransactionUnitTestController transactionUnitTestController = new TransactionUnitTestController();
            IActionResult result = transactionUnitTestController.Delete(1) as IActionResult;
            Assert.IsNotNull(result);
        }



    }//end of transaction controller test class
}