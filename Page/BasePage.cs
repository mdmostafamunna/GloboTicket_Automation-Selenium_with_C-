using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket_Automation_Selenium_with_C__.Page
{
    internal class BasePage
    {

        protected IWebDriver driver;

        protected BasePage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        protected void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", element);
            Thread.Sleep(4000);
        }
    }
}
