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
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments(GetBrowserArguments());
                    return new ChromeDriver(chromeOptions);

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArguments(GetBrowserArguments());
                    return new FirefoxDriver(firefoxOptions);

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArguments(GetBrowserArguments());
                    return new EdgeDriver(edgeOptions);

                default:
                    throw new Exception("Provided browser is not supported!");
            }
        }

        public string[] GetBrowserArguments()
        {
            if (ConfigurationProvider.Configuration["browserArguments"] != null)
            {
                return ConfigurationProvider.Configuration["browserArguments"].Split(",");
            }
            return Array.Empty<string>();
        }
    }
}
