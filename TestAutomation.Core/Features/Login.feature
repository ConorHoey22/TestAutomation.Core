Feature: Login

A short summary of the feature

@validLogin
Scenario: Login with valid credentials
	Given the user is on the login page
	When the user enters valid credentials
	Then the user should be redirected to the dashboard

	
@invalidLogin
Scenario: Attempts to login with invalid credentials
	Given the user is on the login page
	When the user enters invalid credentials
	Then validation should appear