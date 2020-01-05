﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TransforMe.Test
{
    [TestClass]
    public class RegisterTests
    {
        private IWebDriver _driver;
        private Uri _localLogin = new Uri("https://localhost:44384/");
        private Uri _localRegister = new Uri("https://localhost:44384/Home/Register");

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();

            _driver.Navigate().GoToUrl(_localLogin);
            _driver.FindElement(By.Name("noaccount")).Click();
        }

        [TestMethod]
        public void Homepage_Loaded_Succesfull()
        {
            Assert.IsTrue(_driver.PageSource.Contains("Repeat password"));
        }

        [TestMethod]
        public void New_User_Registration_Succefull()
        {
            // Form is been filled

            _driver.FindElement(By.Name("firstname")).SendKeys("TestFirstname");
            _driver.FindElement(By.Name("lastname")).SendKeys("TestLastname");
            _driver.FindElement(By.Name("username")).SendKeys("TestUsername");
            _driver.FindElement(By.Name("password")).SendKeys("TestPassword");
            _driver.FindElement(By.Name("confirmpassword")).SendKeys("TestPassword");
            var securityquestion = _driver.FindElement(By.Name("securityquestion"));
            var selectElement = new SelectElement(securityquestion);
            selectElement.SelectByText("In what city or town was your first job?");
            _driver.FindElement(By.Name("securityanswer")).SendKeys("TestSecurityAnswer");
            _driver.FindElement(By.Id("registerbtn")).Click();

            // Assert

            Assert.IsTrue(_driver.PageSource.Contains("TestFirstname TestLastname succesfully registered!"));

            //TODO: extra check, die waarschijnlijk niet noodzakelijk is *soon deleted*
            Assert.AreEqual(_driver.Url , _localRegister);

            _driver.Close();
            _driver.Dispose();
        }


    }
}
