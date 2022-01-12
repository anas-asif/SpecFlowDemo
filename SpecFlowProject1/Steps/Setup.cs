using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    class Setup
    {

        public static WebClient client;
        public static XrmApp xrmApp;

        private static BrowserOptions _options = new BrowserOptions
        {
            BrowserType = BrowserType.Chrome,
            PrivateMode = true,
            FireEvents = false,
            Headless = false,
            UserAgent = false,
        };

        [BeforeTestRun]
        public static void startPoint() {

            client = new WebClient(_options);
            xrmApp = new XrmApp(client);
            client.Browser.Driver.Navigate().GoToUrl("https://junaiddemo.crm4.dynamics.com/");
        }
    }
}
