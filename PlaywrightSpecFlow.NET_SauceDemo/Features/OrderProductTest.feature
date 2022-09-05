Feature: OrderProductTest
	Background: 
		Given I navigate to Sauce Demo
		When I successfully logged in

@mytag
Scenario: Order single product
	When I select random product
	Then I verify Product Description page is opened
	And I verify label on Products Page and Single Product Page are equal
	And I verify description on Products Page and Single Product Page are equal