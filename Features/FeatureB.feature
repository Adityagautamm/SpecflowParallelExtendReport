Feature: Feature B
@tagB
Scenario: Scenario two
	Given I navigate to Mens Tennis Shoe page
	When I save the value of shoe 2 price element as alias price
	When I click on shoe 2 element
	Then I am on the Shoe2 page
	Then I Verify the element Price to be equal to alias price
