Feature: OrderProductTest
	
Background: 
	Given I navigate to Sauce Demo
	When I successfully logged in

	@orderTest
Scenario: Order single product
	When I select random product
	Then I verify Product Description page is opened
	And I verify label on Products Page and Single Product Page are equal         
	And I verify description on Products Page and Single Product Page are equal         
	And I verify price on Products Page and Single Product Page are equal         
	When I click 'Add To Cart' button on Product Page         
	Then I verify cart badge contains value '1'         
	When I click 'Remove' button on Product Page         
	Then I verify cart badge not visible         
	When I click 'Add To Cart' button on Product Page         
	And Click on cart icon         
	Then I verify Cart Page is opened
	And I verify label on Products Page and Cart Page are equal
	And I verify description on Products Page and Cart Page are equal
	And I verify price on Products Page and Cart Page are equal
	When I click Checkout button on Cart Page
	Then I verify Your Information Page is opened
	When I type required info
		| FirstName | LastName | PostalCode |
		| Chuck     | Norris   | 210009h    |
	