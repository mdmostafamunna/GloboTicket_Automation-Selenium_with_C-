using GloboTicket_Automation_Selenium_with_C__.Page;
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
    }
}
