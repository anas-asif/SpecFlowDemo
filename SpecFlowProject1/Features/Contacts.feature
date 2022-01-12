Feature: Contacts
	This feature file covers the scenarios related to contacts

@Contacts
Scenario: 01 User is able to view Contacts list
	Given User is Logged in
	When User Clicks on Contacts from left menu
	Then Contact list view loads up

Scenario: 02 User is able to create new Contact
	Given User has session
	And User is on contact list screen
	When user clicks New button
	Then New contact form shows up
	When user clicks submit on Empty form
	Then Form shows validation
	When Mandatory field are filled and saved
	Then Form is submitted successfully

Scenario: 03 User is able to search the Newly created contact
	Given User is logged in and on Dashboard
	And User is on contact list screen
	When user enters Newly created contact name in search field
	And clicks search
	Then Newly created contact shows up on list view
