﻿Feature: OrderProductTest
	Background: 
		Given I navigate to Sauce Demo
		When I successfully looged in
		| username      | password     |
		| standard_user | secret_sauce |

@mytag
Scenario: Order single product
	When I select random