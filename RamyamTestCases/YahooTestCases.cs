using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Windows.Forms;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace RamyamTestCases
{
    [TestClass]
    public class YahooTestCases
    {
        IWebDriver _driver;
        Actions _actions;

        [TestInitialize]
        public void Login()
        {
            _driver = new FirefoxDriver();
            _driver.Url = "https://login.yahoo.com/config/mail?&.src=ym&.intl=uk";
            _driver.FindElement(By.Id("login-username")).SendKeys("sudeepthi.mogalapalli");
            _driver.FindElement(By.Id("login-passwd")).SendKeys("SudeeAdi2712");
            _driver.FindElement(By.Id("login-signin")).Click();
            Thread.Sleep(4000);
        }

        [TestMethod]
        public void Compose()
        {
            
            _driver.FindElement(By.XPath(".//*[@id='Compose']/button")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("to-field")).SendKeys("aaditya29@gmail.com");
            
            _driver.FindElement(By.Id("subject-field")).SendKeys("Bujjiiiiiiii");
            _driver.FindElement(By.Id("rtetext")).SendKeys("I Love You Buddi Gadaaa");
            _driver.FindElement(By.XPath(".//*[@id='attachment-button-input']")).Click();
            SendKeys.SendWait(@"C:\Challengesfacedwithseleniumwebdriver.docx");
            SendKeys.SendWait(@"{Enter}");

            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
          
            _driver.FindElement(By.LinkText("Send")).Click();

        }

        [TestCleanup]
        public void Cleanup()
        {
             IWebElement ele = _driver.FindElement(By.XPath(".//*[@id='yui_3_10_3_1_1375219693637_127']"));
            _actions.MoveToElement(ele).Perform();
            _driver.FindElement(By.LinkText("Sign out")).Click();
            _driver.Close();
            _driver.Quit();
        }
    }
}
