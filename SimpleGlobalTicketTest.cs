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

        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); //Open the Chrome browser.
            driver.Manage().Window.Maximize(); // this code is for miximising the browser window.
            driver.Navigate().GoToUrl("http://localhost:4200"); // This is the local host url, where we run your GlobalTicket project.
        }

        [TearDown]
        public void TearDown()
        {
          driver.Quit();
        }
        [Test]
        public void SimpleTest()
        {
            driver.FindElement(By.Id("full-name")).SendKeys("Munna"); // This is the code where we find the name element by ID and type name with SendKeys method.
            driver.FindElement(By.Id("add-btn")).Click(); // This is the code where we find out the Add button by ID and Click on the button by Click(); method.

        


        }

        [Test]
        public void UsingRelativeLocatorsTest()
        {

            Thread.Sleep(5000);
            driver.FindElement(RelativeBy
                .WithLocator(By.TagName("textarea"))
                .Below(By.Id("full-name")))
                .SendKeys("Something Important");

           
        }

        [Test]
        public void SimpleTestAssertion()
        {
            

            driver.FindElement(By.Id("full-name")).SendKeys("Munna"); // This is the code where we find the name element by ID and type name with SendKeys method.

            Thread.Sleep(5000);
            driver.FindElement(By.Id("add-btn")).Click(); // This is the code where we find out the Add button by ID and Click on the button by Click(); method.

            // Using Assertion

            var totalPrice = driver.FindElement(By.CssSelector("tfoot tr th:nth-child(3)"));
            Assert.AreEqual("$100.00", totalPrice.Text, "Total price is not valid.");
           


        }

        [Test]
        public void UsingSendKeysAndClearTest()
        {

            var notesTestArea = driver.FindElement(By.Id("notes"));
            notesTestArea.SendKeys("Will arrive a but late");
            notesTestArea.Clear();
            notesTestArea.SendKeys("5% discount");

            Assert.That(notesTestArea.GetAttribute("value"), Is.EqualTo("5% discount"));

            var photoInput = driver.FindElement(By.Id("photo"));
            photoInput.SendKeys(Path.GetFullPath(Path.Join("Data", "photo.png")));



        }


        [Test]
        public void PressingKeysTest()
        {

            
            var nameInput = driver.FindElement(By.Id("full-name"));
            nameInput.SendKeys("Josh Smith");


            nameInput.SendKeys(Keys.Control + "A");
            nameInput.SendKeys(Keys.Control + "C");
            Thread.Sleep(5000);
            nameInput.Clear();
            Thread.Sleep(5000);
            nameInput.SendKeys(Keys.Control + "V");




        }

        [Test]
        public void SelectingDropdownOptionTest()
        {


            var includeLunchDropdown = driver.FindElement(By.Id("include-lunch"));
            var includeLunchSelectElement = new SelectElement(includeLunchDropdown);

            includeLunchSelectElement.SelectByText("Yes");
            Assert.That(includeLunchSelectElement.SelectedOption.GetAttribute("value"), Is.EqualTo("true"));

            includeLunchSelectElement.SelectByValue("false");
            Assert.That(includeLunchSelectElement.SelectedOption.Text, Is.EqualTo("No"));


        }
        [Test]
        public void SelectingCheckboxItemsTest()
        {
            var workshop1 = driver.FindElement(By.Id("workshop-1"));

            if(!workshop1.Selected)
            {
                workshop1.Click();
            }

            Assert.That(workshop1.Selected, Is.True);


        }
    }
}
