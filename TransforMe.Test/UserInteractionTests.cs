using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TransforMe.Test
{
    [TestClass()]
    public class UserInteractionTests
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
        public void Follow_User_Success()
        {
            _driver.FindElement(By.Name("searchInput")).SendKeys("user2follow");
            _driver.FindElement(By.Id("searchBtn")).Click();
            _driver.FindElement(By.Id("followBtn")).Click();

            // Assert

            Assert.IsTrue(_driver.PageSource.Contains("follow me followed successfully!"));
        }

        [TestMethod()]
        public void Unfollow_User_Success()
        {
            _driver.FindElement(By.Name("searchInput")).SendKeys("user2unfollow");
            _driver.FindElement(By.Id("searchBtn")).Click();
            _driver.FindElement(By.Id("followBtn")).Click();

            // Assert

            Assert.IsTrue(_driver.PageSource.Contains("unfollow me unfollowed successfully!"));
        }


        //TODO : Whenever feeling like upgrading this application, these tests must be done
        //[TestMethod()]
        public void Like_User_Success()
        {
            throw new NotImplementedException();
        }

        //[TestMethod()]
        public void Dislike_User_Success()
        {
            throw new NotImplementedException();
        }
    }
}
