using NUnit.Framework;
using SpecFlowProject1.Helper;
using SpecFlowProject1.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class ContactsSteps : Hooks.Setup
    {
        SeleniumWaits wait;
        CSVnForms_Ops forms;

        [Given(@"User has session")]
        [Given(@"User is Logged in")]
        [Given(@"User is already logged in")]
        public void GivenUserIsLoggedIn()
        {
            wait = new SeleniumWaits();
            try { wait.specifiedElementText(client, "Contacts"); } catch (Exception e) { String error = e.Message; }
        }




        [Given(@"User is on (.*) list screen")]
        public void GivenUserIsOnContactListScreen(String p1)
        {
            wait = new SeleniumWaits();
            try { wait.specifiedElementText(client, p1); }
            catch (Exception e)
            {
                String error = e.Message;
            }
        }

        [Given(@"User Clicks on (.*) from left menu under (.*) heading")]
        public void WhenUserClicksOnContactsFromLeftMenu(String p1, String p2)
        {
            xrmApp.Navigation.OpenSubArea(p2, p1);
        }

        [When(@"Clicks on (.*)")]
        [When(@"user clicks (.*) button")]
        public void WhenUserClicksNewButton(String p1)
        {
            xrmApp.CommandBar.ClickCommand(p1);


        }

        [When(@"user clicks submit on Empty form")]
        public void WhenUserClicksSubmitOnEmptyForm()
        {
            forms = new CSVnForms_Ops(client, xrmApp);
            xrmApp.ThinkTime(3000);
            Assert.IsTrue(forms.save(),forms.Message);
        }
        [When(@"User enters newly created Lead's (.*) in search field")]
        public void search(String p1) {
            forms = new CSVnForms_Ops(client,xrmApp);
            forms.search(p1);

            xrmApp.ThinkTime(3000);

        }

        [When(@"Mandatory field are filled and saved using (.*)")]
        public void WhenMandatoryFieldAreFilledAndSaved(String p1)
        {
            forms = new CSVnForms_Ops(client, xrmApp);
            Assert.IsTrue(forms.fillAllFields(p1), forms.Message);
        }

        [When(@"User opens the record")]
        public void openRecordVerify() {
            wait = new SeleniumWaits();
            try { wait.specifiedElementText(client, "Summary"); } catch (Exception e) { String error = e.Message; }

        }



        [Then(@"Search result appears with Lead's (.*)")]
        public void verifySearch(String p1)
        {
            try {
                forms.verifySearch(p1);

            } catch (Exception e) { }
        }

        [Then(@"Contact list view loads up")]
        [Then(@"My Open Lead view list loads up")]
        public void ThenContactListViewLoadsUp()
        {
            wait.specifiedElementText(client, "New");
        }

        [Then(@"New contact form shows up using (.*)")]
        public void ThenNewContactFormShowsUp(String p1)
        {
            forms = new CSVnForms_Ops(client, xrmApp);
            Assert.IsTrue(forms.validateAllFields(p1), forms.Message);
        }

        [Then(@"Form shows validation using (.*)")]
        public void ThenFormShowsValidation(String p1)
        {
            forms = new CSVnForms_Ops(client, xrmApp);
            Assert.IsTrue(forms.checkMandatoryValidation(p1),forms.Message);
        }

        [Then(@"Form is submitted successfully")]
        public void ThenFormIsSubmittedSuccessfully()
        {
            forms.save();
            xrmApp.ThinkTime(6000);
        }

        [Then(@"Lead is qualified as an (.*)")]
        public void confirmConversion(String p1)
        {
            wait = new SeleniumWaits();
            try { wait.withXpath(client, "//span[text()='"+p1+"']"); } catch (Exception e) { String error = e.Message; }
        }
    }
}
