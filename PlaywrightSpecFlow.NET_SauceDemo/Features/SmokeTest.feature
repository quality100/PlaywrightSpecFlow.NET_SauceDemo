Feature: SmokeTest
Background: 
	Given I navigate to Sauce Demo
	
@smoke
Scenario: Login test - success
	When I enter following login details
	| username      | password     |
	| standard_user | secret_sauce |
	And I click Login button
	Then I verify Products page title is visible
	
@smoke	
Scenario: Login test - invalid credentials
	When I enter following login details
	  | username         | password         |
	  | Invalid_username | Invalid_password |
	And I click Login button
	Then I verify invalid credentials error message
	
@smoke
Scenario: Login test - retry
	When I enter following login details
	  | username         | password         |
	  | Invalid_username | Invalid_password |
	And I click Login button
	Then I verify invalid credentials error message
	When I close error message
	Then I verify error message not visible
	When I clear username and password fields
	And  I enter following login details
	  | username      | password     |
	  | standard_user | secret_sauce |
	And I click Login button
	Then I verify Products page title is visible