using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Abstraction;
using TestAutomation.Core.Reports;
using TestAutomation.Core.Resources;

namespace TestAutomation.Core.Pages
{
    public class CartPage
    {

        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly ApplicationSettings _applicationSettings;
        private readonly FrameworkSettings _frameworkSettings;
        private readonly IExtentReport _extentReport;
        ScenarioContext sc;
        FeatureContext fc;



        public CartPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _applicationSettings = new ApplicationSettings();
            _applicationSettings.LoadApplicationSettings(); // Load credentials and URL if needed
            var report = (IExtentReport)fc["iextentreport"];
        }

        public void checkCart()
        {

            var productName = _driver.FindElement(By.ClassName("inventory_item_name")).Text;

            if (productName == _applicationSettings.productName)
            {

                Console.WriteLine("Item is present in the cart.");
            }
            else
            {
                Console.WriteLine("Item is not present in the cart.");
            }
        }

        public void proceedWithCheckout()
        {
            // Click on the checkout button
            var checkoutButton = _driver.FindElement(By.CssSelector("a.btn_action.checkout_button"));
            checkoutButton.Click();

            var firstNameField = _driver.FindElement(By.Id("first-name"));
            var lastNameField = _driver.FindElement(By.Id("last-name"));
            var postalCodeField = _driver.FindElement(By.Id("postal-code"));

            firstNameField.SendKeys("Conor");
            lastNameField.SendKeys("Test"); 
            postalCodeField.SendKeys("BT232DA");

            // Click on the continue button
            var continueButton = _driver.FindElement(By.CssSelector("input.btn_primary.cart_button"));
            continueButton.Click();

        }
    
        public void completeCheckoutInformation()
        {
            // Verify if the user is on the checkout overview page
            var checkoutOverviewHeader = _driver.FindElement(By.ClassName("subheader")).Text;

            if (checkoutOverviewHeader.Contains("Checkout: Overview"))
            {
                Console.WriteLine("User is on the checkout overview page.");

                // Click on the finish button to complete the checkout
                var finishButton = _driver.FindElement(By.CssSelector("a.btn_action.cart_button"));
                finishButton.Click();
            }
            else
            {
                Console.WriteLine("User is not on the checkout overview page.");
            }

        }

        public void invalidCheckout()
        {
            
        }

        public void goBackToCart()
        {
            // Click on the back to cart button
   
        }

        public void continueShoppingButton()
        {

        }

    }
}
