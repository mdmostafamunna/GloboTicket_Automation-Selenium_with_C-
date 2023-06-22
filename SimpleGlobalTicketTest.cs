using GloboTicket_Automation_Selenium_with_C__.Page;
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
    public class SimpleGlobalTicketTest : BaseTest
    {

        private OrderPage orderPage;

        [SetUp]
        public new void SetUp()
        {
            orderPage = new OrderPage(GetDriver());
        }


        [Test]
        [Category("Test without assertion")]
        public void SimpleTest()
        {
            orderPage.EnterName("Munna"); // This is the code where we find the name element by ID and type name with SendKeys method.
            orderPage.ClickAddButton(); // This is the code where we find out the Add button by ID and Click on the button by Click(); method.

        }

        [Test]
        public void UsingRelativeLocatorsTest()
        {

            orderPage.SelectWorkshop(0);

           
        }

        [Test]
        [Description("Test with assertion")]
        public void SimpleTestAssertion()
        {


            orderPage.EnterName("Munna"); // This is the code where we find the name element by ID and type name with SendKeys method.
            orderPage.ClickAddButton(); // This is the code where we find out the Add button by ID and Click on the button by Click(); method.

            // Using Assertion
            Assert.That(orderPage.GetTotalPrice(), Is.EqualTo("$100.00"), "Total price is not valid.");
           


        }

        [Test]
        public void UsingSendKeysAndClearTest()
        {

            var notesTestArea = GetDriver().FindElement(By.Id("notes"));
            notesTestArea.SendKeys("Will arrive a but late");
            notesTestArea.Clear();
            notesTestArea.SendKeys("5% discount");

            Assert.That(notesTestArea.GetAttribute("value"), Is.EqualTo("5% discount"));

            var photoInput = GetDriver().FindElement(By.Id("photo"));
            photoInput.SendKeys(Path.GetFullPath(Path.Join("Data", "photo.png")));



        }


        [Test]
        public void PressingKeysTest()
        {

            
            var nameInput = GetDriver().FindElement(By.Id("full-name"));
            nameInput.SendKeys("Josh Smith");


            nameInput.SendKeys(Keys.Control + "A");
            nameInput.SendKeys(Keys.Control + "C");
            nameInput.Clear();
            nameInput.SendKeys(Keys.Control + "V");




        }

        [Test]
        public void SelectingDropdownOptionTest()
        {


            var includeLunchDropdown = GetDriver().FindElement(By.Id("include-lunch"));
            var includeLunchSelectElement = new SelectElement(includeLunchDropdown);

            includeLunchSelectElement.SelectByText("Yes");
            Assert.That(includeLunchSelectElement.SelectedOption.GetAttribute("value"), Is.EqualTo("true"));

            includeLunchSelectElement.SelectByValue("false");
            Assert.That(includeLunchSelectElement.SelectedOption.Text, Is.EqualTo("No"));


        }
        [Test]
        public void SelectingCheckboxItemsTest()
        {
            var workshop1 = GetDriver().FindElement(By.Id("workshop-1"));

            if(!workshop1.Selected)
            {
                workshop1.Click();
            }

            Assert.That(workshop1.Selected, Is.True);


        }
    }
}
