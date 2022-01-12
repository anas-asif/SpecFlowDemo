using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class ContactsSteps
    {
        [Given(@"User is Logged in")]
        public void GivenUserIsLoggedIn()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User has session")]
        public void GivenUserHasSession()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User is on contact list screen")]
        public void GivenUserIsOnContactListScreen()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User is logged in and on Dashboard")]
        public void GivenUserIsLoggedInAndOnDashboard()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User Clicks on Contacts from left menu")]
        public void WhenUserClicksOnContactsFromLeftMenu()
        {

        }
        
        [When(@"user clicks New button")]
        public void WhenUserClicksNewButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"user clicks submit on Empty form")]
        public void WhenUserClicksSubmitOnEmptyForm()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Mandatory field are filled and saved")]
        public void WhenMandatoryFieldAreFilledAndSaved()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"user enters Newly created contact name in search field")]
        public void WhenUserEntersNewlyCreatedContactNameInSearchField()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"clicks search")]
        public void WhenClicksSearch()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Contact list view loads up")]
        public void ThenContactListViewLoadsUp()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"New contact form shows up")]
        public void ThenNewContactFormShowsUp()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Form shows validation")]
        public void ThenFormShowsValidation()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Form is submitted successfully")]
        public void ThenFormIsSubmittedSuccessfully()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Newly created contact shows up on list view")]
        public void ThenNewlyCreatedContactShowsUpOnListView()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
