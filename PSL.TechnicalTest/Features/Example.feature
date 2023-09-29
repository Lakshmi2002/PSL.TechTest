Feature: Example

A short summary of the feature

#Create a branch off main; name the branch using your first and last name, e.g 'john-smith'. Please don't push any code to main.
#Implement code on your branch to test navigating to the amazon.co.uk website,
#selecting an item (example: a sports watch) and adding this to the basket. 
#You must write your tests using the 'gherkin' syntax.
##Add one or two extra tests of your own (using Amazon as the Application Under Test).
#
#Use the file structure provided.
#Be able to build your code and run tests successfully.
#Push your branch/code for review, once completed.

@tag1
Scenario: Add a sports watch to basket
	Given I am navigated to amazon homepage
	And I search for a sports watch
	When I add the item to the basket
	Then sports watch is added to basket
