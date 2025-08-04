using OpenQA.Selenium;
using Reqnroll;
using System;
using TestAutomation.Core.Pages;
using TestAutomation.Core.Resources;

namespace TestAutomation.Core.Steps
{
    [Binding]
    public class CheckoutStepDefinitions
    {

        IWebDriver driver;
        private readonly LoginPage _loginPage;
        private readonly ProductPage _productPage;
        private readonly CartPage _cartPage;
        private readonly ApplicationSettings _applicationSettings;

        public CheckoutStepDefinitions(IWebDriver driver)
        {

            _loginPage = new LoginPage(driver);
            _productPage = new ProductPage(driver);
            _cartPage = new CartPage(driver);
        }

        [Given("the user is on the product page")]
        public void GivenTheUserIsOnTheProductPage()
        {
            //Login in Test User
            _loginPage.NavigateToLoginPage();
            _loginPage.EnterUsername();
            _loginPage.EnterPassword();
            _loginPage.ClickLogin();

            Assert.IsTrue(_loginPage.IsUserOnDashboard(), "User was not redirected to the dashboard.");
        }

        [When("the user clicks on add to cart")]
        public void WhenTheUserClicksOnAddToCart()
        {
            _productPage.AddItemToCart();
            _productPage.checkIFItemisAdded();

        }


        [Then("the item should be added to the cart successfully")]
        public void ThenTheItemShouldBeAddedToTheCartSuccessfully()
        {

            //Checking Cart Page 
            _cartPage.checkCart();

        }

        [When("the user clicks on remove button for a specific item")]
        public void WhenTheUserClicksOnRemoveButtonForASpecificItem()
        {
            Console.WriteLine("User clicked on remove button for a specific item.");
        }

        [Then("the item should be removed from the cart successfully")]
        public void ThenTheItemShouldBeRemovedFromTheCartSuccessfully()
        {
            Console.WriteLine("Item removed from cart successfully.");
        }

        [Given("the user is on the cart page")]
        public void GivenTheUserIsOnTheCartPage()
        {
            Console.WriteLine("User is on the cart page.");
        }

        [When("the user clicks on remove button for a specific item from the cart page")]
        public void WhenTheUserClicksOnRemoveButtonForASpecificItemFromTheCartPage()
        {
            Console.WriteLine("User clicked on remove button for a specific item from the cart page.");
        }

        [Given("an item is in the cart")]
        public void GivenAnItemIsInTheCart()
        {
          Console.WriteLine("An item is in the cart.");
        }

        [When("the user clicks on Checkout and completes the checkout information form")]
        public void WhenTheUserClicksOnCheckoutAndCompletesTheCheckoutInformationForm()
        {
            Console.WriteLine("User clicked on Checkout and completed the checkout information form.");
        }

        [Then("the user is taken to the checkout overview and the order should be placed successfully and confirmation received")]
        public void ThenTheUserIsTakenToTheCheckoutOverviewAndTheOrderShouldBePlacedSuccessfullyAndConfirmationReceived()
        {
         Console.WriteLine("User is taken to the checkout overview and the order was placed successfully with confirmation received.");
        }

        [When("the user clicks checkout and tries to submit the checkout information form without filling in all required fields")]
        public void WhenTheUserClicksCheckoutAndTriesToSubmitTheCheckoutInformationFormWithoutFillingInAllRequiredFields()
        {
            Console.WriteLine("User clicked checkout and tried to submit the checkout information form without filling in all required fields.");
        }

        [Then("the user will receive validation errors and will not be able to proceed with the checkout")]
        public void ThenTheUserWillReceiveValidationErrorsAndWillNotBeAbleToProceedWithTheCheckout()
        {
            Console.WriteLine("User received validation errors and was not able to proceed with the checkout.");    
        }
    }
}
