Feature: OrderProducts

Verify if we can Order and Checkout  products


@Test
Scenario Outline: Checkout Products
	Given User is on SwagLabs Login Page
	And User verifies that the site header logo is displayed
	When User populates login fields with "<UserName>" and "<Password>"
	And User clicks on the login button on the Login Page

	Then  User is navigated to the Inventory Page
	And User verifies if there are products in the Inventory Page
	When User adds products to the Cart in the Inventory Page
	And User clicks on the Shopping Cart icon in the Inventory Page

	Then User is navigated to the Checkout Page.
	And User verifies the product name and price in the Checkout Page
	When User clicks the Checkout button in the checkout page

	Then User is navigated to the Checkout information page
	And User verifies the Checkout information page
	When User populates the information page in the Checkout Information Page with "<FirstName>", "<LastName>"  and "<ZipCode>"
	And User clicks the continue button in the Checkout Information Page

	Then User is navigated to the Checkout Overview Page
	And User verifies the payment information, shipping information, item total, tax and total values int the Overview Page
	When User clicks Finish button in the Checkout Overview Page
	
	Then User is navigated to the Checkout Complete Page
	And User verifies the Thank you header and description in the Checkout Overview Page
	When User Clicks Back Home button in the Checkout Overview Page
	Then User is navigated again to the Inventory Page
	When User clicks the menu button in the Inventory Page
	And User clicks on the logout button in the menu


	Examples:
	| UserName      | Password     | FirstName | LastName | ZipCode |
	| standard_user | secret_sauce | auto1     | test     | 4123    |
