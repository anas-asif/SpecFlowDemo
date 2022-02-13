@ignore
@Sales
Feature: Sales
	This feature file covers the scenarios related to sales area

@Contacts
Scenario: 01 User is able to view Lead Contact List
	Given User is Logged in
	And User Clicks on Contacts from left menu under Sales heading
	Then Contact list view loads up


@Contacts
Scenario: 02 Verify all business required Contact fields are present in the Lead's Contact form
	Given User has session
	And User Clicks on Contacts from left menu under Sales heading
	And User is on My Active Contacts list screen
	When user clicks New button
	Then New contact form shows up using ContactForm

@Contacts
Scenario: 03 Verify Contact fields are mandatory as per business requirements on the form
	Given User has session
	And User Clicks on Contacts from left menu under Sales heading
	And User is on My Active Contacts list screen
	When user clicks New button
	When user clicks submit on Empty form
	Then Form shows validation using ContactForm

@Contacts
Scenario: 04 Creating a contact lead
	Given User has session
	And User Clicks on Contacts from left menu under Sales heading
	And User is on My Active Contacts list screen
	When user clicks New button
	When Mandatory field are filled and saved using ContactForm
	Then Form is submitted successfully

@leads
Scenario: 05 User is able to view My Open Leads List
	Given User is Logged in
	And User Clicks on Leads from left menu under Sales heading
	Then My Open Lead view list loads up

@Leads
Scenario: 06 User is able to create new Lead
	Given User has session
	And User is on My Open Leads list screen
	When user clicks New button
	Then New contact form shows up using LeadForm
	When user clicks submit on Empty form
	Then Form shows validation using LeadForm
	When Mandatory field are filled and saved using LeadForm
	Then Form is submitted successfully

@Leads
Scenario: 07 User is able to qualify newly created Lead
	Given User has session
	And User is on My Open Leads list screen
	When User enters newly created Lead's Last Name in search field
	Then Search result appears with Lead's Last Name
	When User opens the record
	And Clicks on Qualify
	Then Lead is qualified as an Opportunity