using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TransforMe.Test
{
    [TestClass()]
    public class ProfileSearchTests
    {
        private IWebDriver _driver;
        private readonly Uri _localLogin = new Uri("https://localhost:44384/");

        [TestInitialize()]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(_localLogin);
            _driver.FindElement(By.Name("username")).SendKeys("username");
            _driver.FindElement(By.Name("password")).SendKeys("password");
            _driver.FindElement(By.Id("loginbtn")).Click();
        }

        [TestMethod()]
        public void User_Search_Failure_Non_Existing_Username()
        {
            _driver.FindElement(By.Name("searchInput")).SendKeys("nonexistingusername");
            _driver.FindElement(By.Id("searchBtn")).Click();

            // Assert

            Assert.IsTrue(_driver.PageSource.Contains("No user found with the username nonexistingusername"));
        }

        [TestMethod()]
        public void User_Search_Failure_No_Username()
        {
            _driver.FindElement(By.Id("searchBtn")).Click();

            // Assert 

            Assert.IsTrue(_driver.PageSource.Contains("No username given, try again!"));
        }

        [TestMethod()]
        public void User_Search_Success()
        {
            _driver.FindElement(By.Name("searchInput")).SendKeys("username3");
            _driver.FindElement(By.Id("searchBtn")).Click();
            
            // Assert

            Assert.IsTrue(_driver.PageSource.Contains("firstname3 lastname3"));
        }
    }
}
