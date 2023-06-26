using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket_Automation_Selenium_with_C__.Page
{
    internal class OrderPage : BasePage
    {

        public OrderPage(IWebDriver driver) : base(driver)
        {

        }
        private IWebElement Name => driver.FindElement(By.Id("full-name"));
        private IWebElement AddButton => driver.FindElement(By.Id("add-btn"));

        private IWebElement TotalPrice => driver.FindElement(By.CssSelector("tfoot tr th:nth-child(3)"));

        private IWebElement OrderButton => driver.FindElement(By.Id("order-btn"));

        private List<IWebElement> OrderTableItems => driver.FindElements(By.CssSelector(".order-summary tbody tr")).ToList();

        private List<IWebElement> Workshops => driver.FindElements(RelativeBy
                .WithLocator(By.TagName("textarea"))
                .Below(Name))
                .ToList();

        public void EnterName(string text)
        {
            Name.SendKeys(text);
        }

        public void ClickAddButton()
        {
            AddButton.Click();
        }

       public string GetTotalPrice()
        {
            return TotalPrice.Text;
        }
        
       public void SelectWorkshop(int workShopIndex)
        {
            Workshops[workShopIndex].Click();

        }

       public void ClickOrderButton()
        {
            OrderButton.Click();
        }


       

        public void ScrollToTheOrderButton()
        {
            ScrollToElement(OrderButton);
        }

        public void ClickOnTheTicketRemoveButton(int index)
        {
            OrderTableItems[index].FindElement(By.TagName("button")).Click();
        }


        public int GetOrderTicketsCount()
        {
            return OrderTableItems.Count;
        }

        public void ScrollToTheTicketRemoveButton(int index)
        {
            ScrollToElement(OrderTableItems[index]);
        }

        public string GetNameValue()
        {
            return Name.GetAttribute("value");
        }
    }


}
