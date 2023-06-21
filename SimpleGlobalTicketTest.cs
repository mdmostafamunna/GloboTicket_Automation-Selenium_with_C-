using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
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

        [Test]
        public void SimpleTestAssertion()
        {
            var driver = new ChromeDriver(); //Open the Chrome browser.
            driver.Manage().Window.Maximize(); // this code is for miximising the browser window.
            driver.Navigate().GoToUrl("http://localhost:4200"); // This is the local host url, where we run your GlobalTicket project.

            driver.FindElement(By.Id("full-name")).SendKeys("Munna"); // This is the code where we find the name element by ID and type name with SendKeys method.

            Thread.Sleep(5000);
            driver.FindElement(By.Id("add-btn")).Click(); // This is the code where we find out the Add button by ID and Click on the button by Click(); method.

            // Using Assertion

            var totalPrice = driver.FindElement(By.CssSelector("tfoot tr th:nth-child(3)"));
            Assert.AreEqual("$100.00", totalPrice.Text, "Total price is not valid.");
           


            driver.Quit(); // By driver.Quit(); method, the browser will quit.


        }

        [Test]
        public void UsingSendKeysAndClearTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:4200");

            var notesTestArea = driver.FindElement(By.Id("notes"));
            notesTestArea.SendKeys("Will arrive a but late");
            notesTestArea.Clear();
            notesTestArea.SendKeys("5% discount");

            Assert.That(notesTestArea.GetAttribute("value"), Is.EqualTo("5% discount"));

            var photoInput = driver.FindElement(By.Id("photo"));
            photoInput.SendKeys(Path.GetFullPath(Path.Join("Data", "photo.png")));

            driver.Quit();

        }


        [Test]
        public void PressingKeysTest()
        {
            var driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:4200");
            
            var nameInput = driver.FindElement(By.Id("full-name"));
            nameInput.SendKeys("Josh Smith");


            nameInput.SendKeys(Keys.Control + "A");
            nameInput.SendKeys(Keys.Control + "C");
            Thread.Sleep(5000);
            nameInput.Clear();
            Thread.Sleep(5000);
            nameInput.SendKeys(Keys.Control + "V");

            driver.Quit();


        }

        [Test]
        public void SelectingDropdownOptionTest()
        {
            var driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:4200");

            var includeLunchDropdown = driver.FindElement(By.Id("include-lunch"));
            var includeLunchSelectElement = new SelectElement(includeLunchDropdown);

            includeLunchSelectElement.SelectByText("Yes");
            Assert.That(includeLunchSelectElement.SelectedOption.GetAttribute("value"), Is.EqualTo("True"));

            includeLunchSelectElement.SelectByValue("false");
            Assert.That(includeLunchSelectElement.SelectedOption.Text, Is.EqualTo("No"));

            driver.Quit();
        }
        [Test]
        public void SelectingCheckboxItemsTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:4200");

            var workshop1 = driver.FindElement(By.Id("workshop-1"));

            if(!workshop1.Selected)
            {
                workshop1.Click();
            }

            Assert.That(workshop1.Selected, Is.True);

            driver.Quit();

        }
    }
}
