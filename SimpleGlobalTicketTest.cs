using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket_Automation_Selenium_with_C__
{
    public class SimpleGlobalTicketTest
    {
        [Test]
        public void SimpleTest()
        {
            var driver = new ChromeDriver(); //Open the Chrome browser.
            driver.Manage().Window.Maximize(); // this code is for miximising the browser window.
            driver.Navigate().GoToUrl("http://localhost:4200"); // This is the local host url, where we run your GlobalTicket project.

            driver.FindElement(By.Id("full-name")).SendKeys("Munna"); // This is the code where we find the name element by ID and type name with SendKeys method.



            Thread.Sleep(5000);
            driver.FindElement(By.Id("add-btn")).Click(); // This is the code where we find out the Add button by ID and Click on the button by Click(); method.

            driver.Quit(); // By driver.Quit(); method, the browser will quit.


        }

        [Test]
        public void UsingRelativeLocatorsTest()
        {
            var driver = new ChromeDriver(); //Open the Chrome browser.
            driver.Manage().Window.Maximize(); // this code is for miximising the browser window.
            driver.Navigate().GoToUrl("http://localhost:4200"); // This is the local host url, where we run your GlobalTicket project.

            Thread.Sleep(5000);
            driver.FindElement(RelativeBy
                .WithLocator(By.TagName("textarea"))
                .Below(By.Id("full-name")))
                .SendKeys("Something Important");

            driver.Quit(); // By driver.Quit(); method, the browser will quit.
        }
    }
}
