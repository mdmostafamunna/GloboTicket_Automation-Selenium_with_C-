using GloboTicket_Automation_Selenium_with_C__.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket_Automation_Selenium_with_C__
{
    internal class TestingAdditionalSenarios : BaseTest
    {

        private OrderPage orderPage;

        [SetUp]
        public new void SetUp()
        {
            orderPage = new OrderPage(GetDriver());
        }
        [Test]
        public void ScrollingToAnElementTest()
        {
            orderPage.EnterName("Josh Smith");
            orderPage.SelectWorkshop(0);
            orderPage.ClickAddButton();
            Thread.Sleep(3000);
            orderPage.ScrollToTheOrderButton();
            orderPage.ClickOrderButton();
            Thread.Sleep(2000);

            Assert.That(GetDriver().Url, Contains.Substring("success"));
        }


        [Test]
        public void HandlingAlertsAndConfirmationsTest()
        {
            GetDriver().Navigate().GoToUrl("http://localhost:4200/show-alert");

            orderPage.EnterName("Munna");
            orderPage.ClickAddButton();

            Thread.Sleep(5000);
            var alertWindow = GetDriver().SwitchTo().Alert();
            alertWindow.Accept();
            Thread.Sleep(5000);

            orderPage.ScrollToTheTicketRemoveButton(0);
            orderPage.ClickOnTheTicketRemoveButton(0);
            var confirmationWindow = GetDriver().SwitchTo().Alert();
            confirmationWindow.Dismiss();

        }

        [Test]
        public void ManagingWindowsTest()
        {
            var window1 = GetDriver().CurrentWindowHandle;
            orderPage.EnterName("Window 1");

            GetDriver().SwitchTo().NewWindow(WindowType.Window);
            GetDriver().Navigate().GoToUrl("http://localhost:4200");

            var window2 = GetDriver().CurrentWindowHandle;
            orderPage.EnterName("Window 2");

            GetDriver().SwitchTo().Window(window1);
            Assert.That(orderPage.GetNameValue(), Is.EqualTo("Window 1"));

            GetDriver().SwitchTo().Window(window2);
            Assert.That(orderPage.GetNameValue(), Is.EqualTo("Window 2"));

        }
    }
}
