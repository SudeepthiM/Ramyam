using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;

namespace RamyamTestCases
{
    [TestFixture]
    public class RamyaTests
    {
        IWebDriver _driver;
        WebDriverWait wait;
        Actions _actions; 
        
        [TestFixtureSetUp]
        public void Initialize()
        {
            _driver = new FirefoxDriver();
            _actions = new Actions(_driver);
            _driver.Url = "http://www.ramyamlab.com/";
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Title()
	    {
            string title = _driver.Title;
            Debug.WriteLine(title);
            Assert.AreEqual("enliven CEM", title);
	    }

        [Test]
        public void LogoClick()
        {
            _driver.FindElement(By.CssSelector("html body div a#btn_3.Button5")).Click();
            string currentUrl = _driver.Url;
            Assert.AreEqual("http://www.ramyamlab.com/index.html", currentUrl);

        }

        [Test]
        public void HomeImgBtnClick()
	    {
            _driver.FindElement(By.Id("nav_363_B1")).Click();
            Assert.AreEqual("enliven CEM", _driver.Title);
		    _driver.FindElement(By.CssSelector("html body div a img")).Click();
            Assert.AreEqual("http://www.ramyamlab.com/index.html",_driver.Url);
        }

        [Test]
        public void enlivenCEMTab()
        {
            IWebElement _element = _driver.FindElement(By.Id("nav_363_B1"));
            _actions.MoveToElement(_element).Perform();
            _driver.FindElement(By.LinkText("What is Enliven CEM")).Click();
		    Assert.AreEqual("What is Enliven CEM",_driver.Title);

            _driver.Navigate().Back();
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _element = _driver.FindElement(By.XPath(".//*[@id='nav_363_B1']"));
		    _actions.MoveToElement(_element).Perform();
		    _driver.FindElement(By.LinkText("Experience Journey")).Click();
		    Assert.AreEqual("Experience Journey",_driver.Title);

            _element = _driver.FindElement(By.XPath(".//*[@id='nav_350_B1']"));
            _actions.MoveToElement(_element).Perform();
            _driver.FindElement(By.LinkText("The Innovation")).Click();
            Assert.AreEqual("The Innovation", _driver.Title);


		
            //WebElement element3 = driver.findElement(By.xpath(".//*[@id='nav_350_B1']"));
            //actions.moveToElement(element3).perform();
            //driver.findElement(By.linkText("Technology")).click();
            //if(driver.getTitle().equals("Technology"))
            //{
            //    System.out.println("Tab 3(2) is working");
            //}
	
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Close();
        }
    }
}
