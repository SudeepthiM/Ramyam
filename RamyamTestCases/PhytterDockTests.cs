using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using System.Windows.Forms;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace RamyamTestCases
{
    [TestFixture]
    public class PhytterDockTests
    {
        IWebDriver _driver;
        WebDriverWait _wait;

        [TestFixtureSetUp]
        public void InitializeDriver()
        {
            _driver = new FirefoxDriver();
            _driver.Url = "https://www.phytterdock.com/";
        }

        [SetUp]
        public void Login()
        {
            Thread.Sleep(10 * 1000);
            _driver.FindElement(By.Id("userName")).SendKeys("sudeepthi-p");
            _driver.FindElement(By.Id("password")).SendKeys("babasaveme");
            _driver.FindElement(By.XPath(".//*[@id='user']/div/p[3]/button")).Click();

        }

        [Test]
        public void CheckUserLoggedIn()
        {
            var _userName = _driver.FindElement(By.CssSelector(".rev-acpanel-name>a>strong"));
            Assert.AreEqual("sudeepthi-p", _userName.Text);
        }

        [Test]
        public void UploadFile()
        {
            _driver.FindElement(By.Id("upload-button")).Click();

            Thread.Sleep(30 * 1000);
            _driver.FindElement(By.Id("uploadClck")).Click();

            //Action.
            Thread.Sleep(2000);
            SendKeys.SendWait(@"C:\Challengesfacedwithseleniumwebdriver.docx");
            SendKeys.SendWait(@"{Enter}");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            _driver.FindElement(By.Id("uState")).Click();
            var _fileName = _driver.FindElement(By.XPath(".//*[@id='page-files']/tr/td[2]"));
            Assert.AreEqual("Challengesfacedwithseleniumwebdriver.docx", _fileName.Text);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Close();
        }
    }
}
