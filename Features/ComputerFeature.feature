Feature: ComputerFeature
	Create Read Update Delete functionality

@comp
Scenario: Update computer
	Given I navigate to Computers page
	When I click on ACE from list of elements computer Names
	Then I verify element name value equals to ACE
	When I enter text ACE-Update on the element name
	And I click on save element
	Then I verify element alert message text equals to ACE-Update
	And I verify element alert message text equals to updated

@comp
Scenario: Update computer with empty string
	Given I navigate to Computers page
	When I click on ACE from list of elements computer Names
	Then I verify element name value equals to ACE
	When I enter text space on the element name
	And I click on save element
	Then I verify element fail message text equals to Failed to refine type : Predicate isEmpty() did not fail.

@comp
Scenario: Update computer with both dates with right format
	Given I navigate to Computers page
	When I click on ACE from list of elements computer Names
	Then I verify element name value equals to ACE
	When I enter text ACE-Update on the element name
	And I enter text 2008-02-11 on the element introduced
	And I enter text 2008-02-20 on the element discontinued
	And I select Thinking Machines from dropdown Company
	And I click on save element
	Then I verify element alert message text equals to ACE-Update
	And I verify element alert message text equals to updated

@comp
Scenario: Update computer with both dates with wrong format
	Given I navigate to Computers page
	When I click on ACE from list of elements computer Names
	Then I verify element name value equals to ACE
	When I enter text ACE-Update on the element name
	And I enter text 2008-002-11 on the element introduced
	And I enter text 200-02-20 on the element discontinued
	And I select Thinking Machines from dropdown Company
	And I click on save element
	Then I verify element Introduced Error Message text equals to Failed to decode date : java.time.format.DateTimeParseException: Text
	And I verify element Discontinued Error Message text equals to Failed to decode date : java.time.format.DateTimeParseException: Text


@comp
Scenario: Update computer with introduced date with right format
	Given I navigate to Computers page
	When I click on ACE from list of elements computer Names
	Then I verify element name value equals to ACE
	When I enter text ACE-Update on the element name
	And I enter text 2008-02-11 on the element introduced
	And I click on save element
	Then I verify element alert message text equals to ACE-Update
	And I verify element alert message text equals to updated

@comp
Scenario: Update computer with discontinued date with right format
	Given I navigate to Computers page
	When I click on ACE from list of elements computer Names
	Then I verify element name value equals to ACE
	When I enter text ACE-Update on the element name
	And I enter text 2008-02-20 on the element discontinued
	And I click on save element
	Then I verify element alert message text equals to ACE-Update
	And I verify element alert message text equals to updated


@comp
Scenario: Delete computer
	Given I navigate to Computers page
	When I click on ACE from list of elements computer Names
	Then I verify element name value equals to ACE
	When I click on delete element
	Then I verify element alert message text equals to ACE
	And I verify element alert message text equals to deleted


@comp
Scenario: Read computer
	Given I navigate to Computers page
	When I click on ARRA from list of elements computer Names
	Then I verify element name value equals to ARRA

@comp
Scenario: Create computer with both dates with right format
	Given I navigate to Computers page
	When I click on Add Computer element
	Then I am on the Add New Computers page
	When I enter text New Computer on the element name
	And I enter text 2008-02-11 on the element introduced
	And I enter text 2008-02-20 on the element discontinued
	And I select Thinking Machines from dropdown Company
	And I click on Create element
	Then I verify element alert message text equals to New Computer
	And I verify element alert message text equals to created

@comp
Scenario: Create computer with both dates with wrong format
	Given I navigate to Computers page
	When I click on Add Computer element
	Then I am on the Add New Computers page
	When I enter text Newwww on the element name
	And I enter text 2008-002-11 on the element introduced
	And I enter text 200-02-20 on the element discontinued
	And I select Thinking Machines from dropdown Company
	And I click on Create element
	Then I verify element Introduced Error Message text equals to Failed to decode date : java.time.format.DateTimeParseException: Text
	And I verify element Discontinued Error Message text equals to Failed to decode date : java.time.format.DateTimeParseException: Text
