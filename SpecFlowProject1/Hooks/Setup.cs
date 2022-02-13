using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject1.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using System.IO;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public class Setup
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
        public static void setUp() {

            client = new WebClient(_options);
            xrmApp = new XrmApp(client);
            var login = new Login(client,xrmApp);
            String user = "admin@CRM268840.onmicrosoft.com";
            String pwd = "Ry51VgWxpO";
            String url = "https://junaiddemo.crm4.dynamics.com/";
            client.Browser.Driver.Navigate().GoToUrl(url);
            Assert.IsTrue(login.attemptLogin(user, pwd), login.Message);


        }

        [BeforeFeature("Marketing")]
        public static void switchToMarketing() {
            xrmApp.ThinkTime(5000);
            client.Browser.Driver.FindElement(By.XPath("//span[text()='Home']")).Click();
            xrmApp.ThinkTime(5000);
            xrmApp.Navigation.OpenArea("Marketing");
            xrmApp.ThinkTime(2000);
        }

        [BeforeFeature("Sales")]
        public static void switchToSales()
        {
            xrmApp.ThinkTime(5000);
            client.Browser.Driver.FindElement(By.XPath("//span[text()='Home']")).Click();
            xrmApp.ThinkTime(5000);
            xrmApp.Navigation.OpenArea("Sales");
            xrmApp.ThinkTime(2000);
            client.Browser.Driver.FindElement(By.XPath("//span[text()='Home']")).Click();
        }

        [AfterFeature]
        public static void afterFeature() {
            File.Delete(@"formEntryCSV.csv");
        }

        [AfterTestRun]
        public static void tearDown()
        {
            
            client.Browser.Driver.Quit();
        }
    }
}
