using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Pages;

namespace TestAutomation.Core.Steps
{
    public class CheckoutStepsDefinitions
    {


        IWebDriver driver;
        private readonly LoginPage _loginPage;
        private readonly ProductPage _productPage;


        public CheckoutStepsDefinitions(IWebDriver driver)
        {

            _loginPage = new LoginPage(driver);
            _productPage = new ProductPage(driver);
        }

        [Given("the user is on the product page")]
        public void GivenTheUserIsOnTheProductPage()
        {
            //Login in Test User
            _loginPage.NavigateToLoginPage();
            _loginPage.EnterUsername();
            _loginPage.EnterPassword();

            Assert.IsTrue(_loginPage.IsUserOnDashboard(), "User was not redirected to the dashboard.");
        }

        [When("the user clicks on add to cart")]
        public void WhenTheUserClicksOnAddToCart()
        {
            throw new PendingStepException();
        }

        [Then("the item should be added to the cart successfully")]
        public void ThenTheItemShouldBeAddedToTheCartSuccessfully()
        {
            throw new PendingStepException();
        }

        [When("the user clicks on remove button for a specific item")]
        public void WhenTheUserClicksOnRemoveButtonForASpecificItem()
        {
            throw new PendingStepException();
        }

        [Then("the item should be removed from the cart successfully")]
        public void ThenTheItemShouldBeRemovedFromTheCartSuccessfully()
        {
            throw new PendingStepException();
        }

        [Given("the user is on the cart page")]
        public void GivenTheUserIsOnTheCartPage()
        {
            throw new PendingStepException();
        }

        [Given("an item is in the cart")]
        public void GivenAnItemIsInTheCart()
        {
            throw new PendingStepException();
        }

        [When("the user clicks on Checkout and completes the checkout information form")]
        public void WhenTheUserClicksOnCheckoutAndCompletesTheCheckoutInformationForm()
        {
            throw new PendingStepException();
        }

        [Then("the user is taken to the checkout overview and the order should be placed successfully and confirmation received")]
        public void ThenTheUserIsTakenToTheCheckoutOverviewAndTheOrderShouldBePlacedSuccessfullyAndConfirmationReceived()
        {
            throw new PendingStepException();
        }

        [When("the user clicks checkout and tries to submit the checkout information form without filling in all required fields")]
        public void WhenTheUserClicksCheckoutAndTriesToSubmitTheCheckoutInformationFormWithoutFillingInAllRequiredFields()
        {
            throw new PendingStepException();
        }

        [Then("the user will receive validation errors and will not be able to proceed with the checkout")]
        public void ThenTheUserWillReceiveValidationErrorsAndWillNotBeAbleToProceedWithTheCheckout()
        {
            throw new PendingStepException();
        }


    }
}
