Feature: SmokeTest
Background: 
	Given I navigate to Sauce Demo
	
@mytag
Scenario: Login test - success
	When I enter following login details
	| username      | password     |
	| standard_user | secret_sauce |
	And I click Login button
	#Then I verify Products page title is visible
	
Scenario: Login test - invalid credentials
	When I enter following login details
	  | username         | password         |
	  | Invalid_username | Invalid_password |
	And I click Login button