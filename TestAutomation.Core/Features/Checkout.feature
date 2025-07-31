Feature: Checkout

Checkout Functionality

@addToCart
Scenario: User is able to add an items to the cart
	Given the user is on the product page
	When the user clicks on add to cart
	Then the item should be added to the cart successfully

	
@removeFromCartOnProductPage
Scenario: User is able to remove an item from the cart
	Given the user is on the product page 
	When the user clicks on remove button for a specific item
	Then the item should be removed from the cart successfully
	
@removeFromCartOnCartPage
Scenario: User is able to remove an item from the cart within the product page
	Given the user is on the cart page 
	When the user clicks on remove button for a specific item
	Then the item should be removed from the cart successfully



@successfulCheckout
Scenario: User adds items to cart and checks out successfully
	Given an item is in the cart 
	When the user clicks on Checkout and completes the checkout information form
	Then the user is taken to the checkout overview and the order should be placed successfully and confirmation received



@unsuccessfulCheckout
Scenario: User adds items to cart and fails to checkout
	Given an item is in the cart
	When the user clicks checkout and tries to submit the checkout information form without filling in all required fields
	Then the user will receive validation errors and will not be able to proceed with the checkout
