using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TransforMe.Test
{
    [TestClass()]
    public class MessageTests
    {
        private IWebDriver _driver;
        private readonly Uri _localLogin = new Uri("https://localhost:44384/");
        private readonly Uri _localIndex = new Uri("https://localhost:44384/User/Index");

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
        public void Index_Page_Load_Success()
        {
            Assert.AreEqual(_localIndex, _driver.Url);
        }

        [TestMethod()]
        public void Message_Add_Failure_No_Input()
        {
            _driver.FindElement(By.Id("messageBtn")).Click();

            // Assert

            Assert.IsTrue(_driver.PageSource.Contains("Either your input is empty or too long!"));
        }

        [TestMethod()]
        public void Message_Add_Failure_Exceeded_Characters()
        {
            _driver.FindElement(By.Id("message"))
                .SendKeys("Dit is een testbericht van meer dan 300 tekens; " +
                          "Lorem ipsum quis, sem. Nulla consequat massa quis enim. Donec pede justo, " +
                          "fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, " +
                          "venenat Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. "
                          + "In enim justo, rhoncus ut, imperdiet a, venenat.");
            _driver.FindElement(By.Id("messageBtn")).Click();

            // Assert

            Assert.IsTrue(_driver.PageSource.Contains("Either your input is empty or too long!"));
        }

        [TestMethod()]
        public void Message_Add_Success()
        {
            _driver.FindElement(By.Id("message")).SendKeys("test");
            _driver.FindElement(By.Id("messageBtn")).Click();

            // Assert

            Assert.IsTrue(_driver.PageSource.Contains("Message successfully added!"));

        }
    }
}
