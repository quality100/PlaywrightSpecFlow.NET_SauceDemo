Feature: LoginTest
Background: 
	Given I navigate to Sauce Demo
	
	@newPOM_Design
Scenario: Login test - new design
	When I enter following login details --new design
	  | username      | password     |
	  | standard_user | secret_sauce |
	Then I verify Products page title is visible
	
	@loginTest
Scenario: Login test - success
	When I enter following login details
	| username      | password     |
	| standard_user | secret_sauce |
	And I click Login button
	Then I verify Products page title is visible
	
	@loginTest
Scenario: Login test - invalid credentials
	When I enter following login details
	  | username         | password         |
	  | Invalid_username | Invalid_password |
	And I click Login button
	Then I verify invalid credentials error message
	
	@loginTest
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
	
	@loginTest
Scenario: Login test - empty username and password fields
	When I click Login button
	Then I verify empty credentials error message
	
	@loginTest	
Scenario: Login test - empty password field
	When I enter following login details
	  | username      | password |
	  | standard_user |          |
   	And I click Login button
   Then I verify empty password error message