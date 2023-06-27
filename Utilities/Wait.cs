using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket_Automation_Selenium_with_C__.Utilities
{
    public class Wait
    {
        private IWebDriver driver;

        public Wait(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForTheElementToBecomeVisible(Func<IWebElement> element, TimeSpan timespan)
        {
            var wait = new WebDriverWait(driver, timespan);
            wait.Until(_ => element.Invoke().Displayed);
        }
    }
}
