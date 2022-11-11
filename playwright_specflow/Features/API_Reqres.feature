Feature: API_Reqres
	Simple calculator for adding two numbers

@mytag
Scenario: First Api Test
	Given I execute 'GET Single User' request
	Then I verify 'name' field in response is 'Janet1'
	Then I verify 'support text' field in response is 'To keep ReqRes free, contributions towards server costs are appreciated!'
	#Then Db test