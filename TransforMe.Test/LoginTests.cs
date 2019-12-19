using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TransforMe.Test
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver _driver;
        private Uri _localLogin = new Uri("https://localhost:44384/");

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]
        public void Login_Page_Load_Success()
        {
            _driver.Navigate().GoToUrl(_localLogin);

            Assert.AreEqual("Home - TransforMe", _driver.Title);
            Assert.IsTrue(_driver.PageSource.Contains("Sign in"));
        }

        [TestMethod]
        public void User_Login_Success()
        {

        }
    }
}
