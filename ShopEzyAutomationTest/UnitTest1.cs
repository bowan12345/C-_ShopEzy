using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V127.Network;


namespace ShopEzyAutomationTest
{
    [TestClass]
    public class AotumatedUITest
    {
        private readonly IWebDriver driver;
        public AotumatedUITest() { 
            // Set up the driver
            driver = new ChromeDriver();
        }

        private static void DelayForAutomatedUI() 
        { 
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void LaunchBrowser()
        {
            driver.Navigate().GoToUrl("https://localhost:7236/");
            //DelayForAutomatedUI();
            Assert.AreEqual("Index - ShopEzy", driver.Title);
        }

        [TestMethod]
        public void Login()
        {
            driver.Navigate().GoToUrl("https://localhost:7236/Customer/Login");
            driver.FindElement(By.Id("Email")).SendKeys("bw.ding@outlook.com");
            driver.FindElement(By.Id("Password")).SendKeys("123");
            driver.FindElement(By.Id("LoginButton")).Click();
            DelayForAutomatedUI();
            Assert.AreEqual("Index - ShopEzy", driver.Title);
        }

        [TestMethod]
        public void Register()
        { 
            driver.Navigate().GoToUrl("https://localhost:7236/Customer/Register");
            driver.FindElement(By.Id("firstname")).SendKeys("Bing");
            driver.FindElement(By.Id("lastname")).SendKeys("Ding");
            driver.FindElement(By.Id("email")).SendKeys("test.automated2@outlook.com");
            driver.FindElement(By.Id("phonenumber")).SendKeys("123456");
            driver.FindElement(By.Id("dateofbirth")).SendKeys("14/09/2024 12:00:00 am");
            driver.FindElement(By.Id("address")).SendKeys("address");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirmPassword")).SendKeys("123");
            driver.FindElement(By.Id("RegisterButton")).Click();
            DelayForAutomatedUI();
            Assert.AreEqual("Login - ShopEzy", driver.Title);
        }


        [TestMethod]
        public void SearchProduct()
        {
            driver.Navigate().GoToUrl("https://localhost:7236/");
            DelayForAutomatedUI();
            driver.FindElement(By.Id("SearchName")).SendKeys("a");
            driver.FindElement(By.Id("SearchButton")).Click();
            Assert.AreEqual("Index - ShopEzy", driver.Title);
        }

        [TestMethod]
        public void SortProductByName()
        {
            driver.Navigate().GoToUrl("https://localhost:7236/");
            DelayForAutomatedUI();
            driver.FindElement(By.Id("NameSort")).Click();
            Assert.AreEqual("Index - ShopEzy", driver.Title);
        }

        [TestMethod]
        public void SortProductByPrice()
        {
            driver.Navigate().GoToUrl("https://localhost:7236/");
            DelayForAutomatedUI();
            driver.FindElement(By.Id("PriceSort")).Click();
            Assert.AreEqual("Index - ShopEzy", driver.Title);
        }



        [TestMethod]
        public void ViewProductDetails()
        {
            driver.Navigate().GoToUrl("https://localhost:7236/");
            driver.FindElement(By.Id("productDetails")).Click();
            //DelayForAutomatedUI();
            Assert.AreEqual("Details - ShopEzy", driver.Title);
        }


        [TestMethod]
        public void PurchaseProduct()
        {
            driver.Navigate().GoToUrl("https://localhost:7236/");
            DelayForAutomatedUI();
            driver.FindElement(By.Id("loginLink")).Click(); ;
            driver.FindElement(By.Id("Email")).SendKeys("bw.ding@outlook.com");
            driver.FindElement(By.Id("Password")).SendKeys("123");
            DelayForAutomatedUI();
            driver.FindElement(By.Id("LoginButton")).Click();
            DelayForAutomatedUI();
            driver.FindElement(By.Id("productDetails")).Click();
            DelayForAutomatedUI();
            driver.FindElement(By.Id("purchaseButton")).Click();
            Assert.AreEqual("Index - ShopEzy", driver.Title);
        }


        [TestMethod]
        public void ViewTransactionHistory()
        {
            driver.Navigate().GoToUrl("https://localhost:7236/");
            DelayForAutomatedUI();
            driver.FindElement(By.Id("loginLink")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("bw.ding@outlook.com");
            driver.FindElement(By.Id("Password")).SendKeys("123");
            DelayForAutomatedUI();
            driver.FindElement(By.Id("LoginButton")).Click();
            DelayForAutomatedUI();
            driver.FindElement(By.Id("viewTransaction")).Click();
            Assert.AreEqual("Index - ShopEzy", driver.Title);
        }

        [TestMethod]
        public void DeleteTransactionHistory()
        {
            driver.Navigate().GoToUrl("https://localhost:7236/");
            DelayForAutomatedUI();
            driver.FindElement(By.Id("loginLink")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("bw.ding@outlook.com");
            driver.FindElement(By.Id("Password")).SendKeys("123");
            DelayForAutomatedUI();
            driver.FindElement(By.Id("LoginButton")).Click();
            DelayForAutomatedUI();
            driver.FindElement(By.Id("viewTransaction")).Click();
            DelayForAutomatedUI();
            driver.FindElement(By.Id("deleteButton")).Click();
            DelayForAutomatedUI();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            DelayForAutomatedUI();
            Assert.AreEqual("Index - ShopEzy", driver.Title);
        }


        [TestMethod]
        public void ViewCustomerDetails()
        {
            driver.Navigate().GoToUrl("https://localhost:7236/");
            DelayForAutomatedUI();
            driver.FindElement(By.Id("loginLink")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("bw.ding@outlook.com");
            driver.FindElement(By.Id("Password")).SendKeys("123");
            DelayForAutomatedUI();
            driver.FindElement(By.Id("LoginButton")).Click();
            DelayForAutomatedUI();
            driver.FindElement(By.Id("cusomterDetails")).Click();
            DelayForAutomatedUI();
            Assert.AreEqual("User Details - ShopEzy", driver.Title);
        }


        [TestMethod]
        public void UpdateCustomerDetails()
        {
            driver.Navigate().GoToUrl("https://localhost:7236/");
            DelayForAutomatedUI();
            driver.FindElement(By.Id("loginLink")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("bw.ding@outlook.com");
            driver.FindElement(By.Id("Password")).SendKeys("123");
            DelayForAutomatedUI();
            driver.FindElement(By.Id("LoginButton")).Click();
            DelayForAutomatedUI();
            driver.FindElement(By.Id("cusomterDetails")).Click();
            DelayForAutomatedUI();
            driver.FindElement(By.Id("editButton")).Click();
            driver.FindElement(By.Id("Address")).Clear();
            driver.FindElement(By.Id("Address")).SendKeys("new address");
            DelayForAutomatedUI();
            driver.FindElement(By.Id("saveButton")).Click();
            DelayForAutomatedUI();
            Assert.AreEqual("User Details - ShopEzy", driver.Title);
        }

    }
}