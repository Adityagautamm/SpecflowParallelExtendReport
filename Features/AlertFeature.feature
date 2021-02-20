Feature: AlertFeature
	

@alert
Scenario: verify alert
Given I navigate to Alert Page page
When I click on Js ALert element
And I accept the alert
Then I verify element alert message text equals to You successfully clicked an alert

@alert
Scenario: verify alert confirm
Given I navigate to Alert Page page
When I click on Js Confirm element
And I accept the alert
Then I verify element alert message text equals to You clicked: Ok

@alert
Scenario: verify alert prompt
Given I navigate to Alert Page page
When I click on Js Prompt element
And I enter text hello friends in the alert
And I accept the alert
Then I verify element alert message text equals to hello friends
And I verify element alert message text equals to You entered: