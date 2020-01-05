using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TransforMe.Test
{
    [TestClass()]
    public class ProgressionTests : IDisposable
    {
        private IWebDriver _driver;
        private readonly Uri _localLogin = new Uri("https://localhost:44384/");
        private readonly Uri _localProgressionIndex = new Uri("https://localhost:44384/User/ProgressionIndex");

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(_localLogin);
            _driver.FindElement(By.Name("username")).SendKeys("username");
            _driver.FindElement(By.Name("password")).SendKeys("password");
            _driver.FindElement(By.Id("loginbtn")).Click();
            _driver.Navigate().GoToUrl(_localProgressionIndex);

        }

        [TestMethod]
        public void Progression_Add_Failure_No_Image()
        {
            _driver.FindElement(By.Id("bodyweight")).SendKeys("56");
            _driver.FindElement(By.Id("date")).SendKeys("12082020");
            _driver.FindElement(By.Id("progressionBtn")).Click();

            // Assert
            Assert.IsTrue(_driver.PageSource.Contains("Either one (if not more) of the required input fields is empty or the date is not valid!"));
        }

        [TestMethod]
        public void Progression_Add_Failure_No_Bodyweight()
        {
            _driver.FindElement(By.Id("outImage")).SendKeys(@"C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\wwwroot\images\upload.png");
            _driver.FindElement(By.Id("date")).SendKeys("12082020");
            _driver.FindElement(By.Id("progressionBtn")).Click();

            // Assert
            Assert.IsTrue(_driver.PageSource.Contains("Either one (if not more) of the required input fields is empty or the date is not valid!"));
        }

        [TestMethod]
        public void Progression_Add_Failure_No_Date()
        {
            _driver.FindElement(By.Id("outImage")).SendKeys(@"C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\wwwroot\images\upload.png");
            _driver.FindElement(By.Id("bodyweight")).SendKeys("56");
            _driver.FindElement(By.Id("progressionBtn")).Click();

            // Assert
            Assert.IsTrue(_driver.PageSource.Contains("Either one (if not more) of the required input fields is empty or the date is not valid!"));
        }

        [TestMethod]
        public void Progression_Add_Success()
        {
            _driver.FindElement(By.Id("outImage")).SendKeys(@"D:\@kleinejohn\image.jpeg");
            _driver.FindElement(By.Id("bodyweight")).SendKeys("65");
            _driver.FindElement(By.Id("date")).SendKeys("12012015");
            _driver.FindElement(By.Id("progressionBtn")).Click();

            // Assert
            Assert.IsTrue(_driver.PageSource.Contains("Progression successfully added!"));
        }

        public void Dispose()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}
