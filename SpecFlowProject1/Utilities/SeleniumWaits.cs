using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject1.Utilities
{
    class SeleniumWaits
    {
        public void specifiedElementText(WebClient client, string element)
        {

            var wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(240));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[text()='" + element + "']")));
        }

        public void withXpath(WebClient client, string xpath)
        {

            var wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(240));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(xpath)));

            wait.Until(e => e.FindElement(By.XPath(xpath)));

        }
    }
}
