using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TransforMe.Test
{
    [TestClass()]
    public class LoginTests : IDisposable
    {
        private IWebDriver _driver;
        private readonly Uri _localLogin = new Uri("https://localhost:44384/");

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]
        public void Login_Page_Can_Be_Loaded()
        {
            _driver.Navigate().GoToUrl(_localLogin);

            Assert.AreEqual("Home - TransforMe", _driver.Title);
            Assert.IsTrue(_driver.PageSource.Contains("You don't"));
        }

        [TestMethod]
        public void User_Login_Succesfull()
        {
            _driver.Navigate().GoToUrl(_localLogin);

            _driver.FindElement(By.Name("username")).SendKeys("username");
            _driver.FindElement(By.Name("password")).SendKeys("password");
            _driver.FindElement(By.Id("loginbtn")).Click();

            Assert.IsTrue(_driver.PageSource.Contains("Post a message"));
        }

        [TestMethod]
        public void User_Login_Failure_Incorrect_Password()
        {
            _driver.Navigate().GoToUrl(_localLogin);

            _driver.FindElement(By.Name("username")).SendKeys("username");
            _driver.FindElement(By.Name("password")).SendKeys("123");
            _driver.FindElement(By.Id("loginbtn")).Click();

            Assert.IsTrue(_driver.PageSource.Contains("Login failed"));
        }

        [TestMethod]
        public void User_Login_Failure_Incorrect_Username()
        {
            _driver.Navigate().GoToUrl(_localLogin);

            _driver.FindElement(By.Name("username")).SendKeys("jantje");
            _driver.FindElement(By.Name("password")).SendKeys("password");
            _driver.FindElement(By.Id("loginbtn")).Click();

            Assert.IsTrue(_driver.PageSource.Contains("Login failed"));
        }

        public void Dispose()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}
