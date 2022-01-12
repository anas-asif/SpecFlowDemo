using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using SpecFlowProject1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject1.Helper
{
    class Login : BaseHelper
    {
        private SeleniumWaits waiting;

        private string message;

        public string Message { get => message; set => message = value; }
        public Login(WebClient client, XrmApp xrmApp)
        {

            this.client = client;
            this.xrmApp = xrmApp;
            waiting = new SeleniumWaits();

        }



        public bool attemptLogin(String user, String pwd)
        {
            var waiting = new SeleniumWaits();

            try
            {





                // Check whether browser is asking to enter Username
                waiting.withXpath(client, "//*[@id='i0116']");
                xrmApp.ThinkTime(2000);
                client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(user);





                client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(Keys.Enter);

                xrmApp.ThinkTime(3000);




                // Check whether browser is asking to enter Password
                waiting.withXpath(client, "//*[@type='password']");
                xrmApp.ThinkTime(2000);
                client.Browser.Driver.FindElement(By.XPath("//*[@type='password']")).SendKeys(pwd);

                xrmApp.ThinkTime(2000);
                client.Browser.Driver.FindElement(By.XPath("//*[@type='password']")).SendKeys(Keys.Enter);


                // Check whether browser is asking for confirmation 'Keep Signing In'
                if (client.Browser.Driver.HasElement(By.Id("idSIButton9")))
                {
                    client.Browser.Driver.FindElement(By.Id("idSIButton9")).SendKeys(Keys.Enter);
                }
                else
                {
                    Message = "No 'Stay Signed In' Dialog appeared";
                }


                waiting.withXpath(client, "//iframe[@id='AppLandingPage']");
                client.Browser.Driver.SwitchTo().Frame("AppLandingPage");
                waiting.specifiedElementText(client, "DryDocks Global Offshore");
                client.Browser.Driver.SwitchTo().DefaultContent();



                xrmApp.Navigation.OpenApp("DryDocks Global Offshore");

                return true;
            }
            catch (Exception e)
            {

                Message = e.Message;
                return false;
            }
        }

        public bool reLogin(String user, String pwd)
        {
            var waiting = new SeleniumWaits();
            bool isSuccess;
            try
            {

                xrmApp.Navigation.SignOut();
                waiting.withXpath(client, "//div[@id='otherTileText']/..");
                client.Browser.Driver.FindElement(By.XPath("//div[@id='otherTileText']/..")).Click();
                isSuccess = attemptLogin(user, pwd);

                if (isSuccess != true)
                {

                    throw new Exception("reLogin method failed at some point.");
                }

                return true;
            }
            catch (Exception e)
            {
                Message = e.Message;
                return false;
            }

        }
    }
}

