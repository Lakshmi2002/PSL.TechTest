Feature: Example

A short summary of the feature

Scenario: Add a sports watch to basket
	Given I am navigated to amazon homepage
	And I search for a sports watch
	When I add the item to the basket
	Then sports watch is added to basket

Scenario: Check whether the page redirects to the product detail page when clicking on the product in the shopping bakset
	Given sports watch is added to basket	
	When I click on the sports watch in the shopping basket
	Then page redirects to the sports watch product detail page

Scenario: Check whether the quantity is decreased when removing sports watch from the basket
	Given sports watch is added to basket	
	And I am on the cart view page
	When I click on the delete link on the shopping basket
	Then shopping basket quantity is zero



