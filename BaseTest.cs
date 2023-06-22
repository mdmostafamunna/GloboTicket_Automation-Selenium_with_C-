using GloboTicket_Automation_Selenium_with_C__.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket_Automation_Selenium_with_C__
{
    public class BaseTest
    {
        private IWebDriver driver;

        protected IWebDriver GetDriver() { 
            return driver; 
        }

        [SetUp]
        public void Setup()
        {
            driver = CreateDriver(ConfigurationProvider.Configuration["browser"]); //Open the Chrome browser.
            driver.Manage().Window.Maximize(); // this code is for miximising the browser window.
            driver.Navigate().GoToUrl(ConfigurationProvider.Configuration["local_url"]); // This is the local host url, where we run your GlobalTicket project.
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        private IWebDriver CreateDriver(string browserName)
        {
            switch(browserName.ToLowerInvariant())
            {
                case "chrome":
                    return new ChromeDriver();

                case "firefox":
                    return new FirefoxDriver();

                case "edge":
                    return new EdgeDriver();

                default:
                    throw new Exception("Provided browser is not supported!");
            }
        }
    }
}
