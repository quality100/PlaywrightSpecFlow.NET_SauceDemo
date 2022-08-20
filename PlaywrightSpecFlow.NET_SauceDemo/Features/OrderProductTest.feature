Feature: OrderProductTest
	Background: 
		Given I navigate to Sauce Demo
		When I successfully looged in
		| username      | password     |
		| standard_user | secret_sauce |

@mytag
Scenario: Order single product
	When I select random product
	Then I verify Product Description page is opened
	And I verify Product description is the same as on Products Page
	Then I verify label on Products Page and Single Product Page are equal