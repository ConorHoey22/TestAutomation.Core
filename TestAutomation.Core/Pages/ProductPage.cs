using AventStack.ExtentReports.Gherkin.Model;
using NuGet.Frameworks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Resources;

namespace TestAutomation.Core.Pages
{
    public class ProductPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly ApplicationSettings _applicationSettings;
        private readonly FrameworkSettings _frameworkSettings;

        public ProductPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _applicationSettings = new ApplicationSettings();
            _applicationSettings.LoadApplicationSettings(); // Load credentials and URL if needed

            
        }

        public void AddItemToCart()
        {
            // find the product by Product Name and click on the add to cart button
            var button = _driver.FindElement(By.XPath($"//div[contains(text(),'{_applicationSettings.productName}')]/ancestor::div[@class='inventory_item']//button"));
       
            button.Click();
        }

        public void RemoveItemFromCart()
        {
            // find the product by Product Name and click on the add to cart button
            var button = _driver.FindElement(By.XPath($"//div[contains(text(),'{_applicationSettings.productName}')]/ancestor::div[@class='inventory_item']//button"));

            button.Click();
        }

        public void checkIFItemisAdded()
        {
            
            var cartIcon = _driver.FindElement(By.ClassName("shopping_cart_link"));

            var cartItemCount = _driver.FindElement(By.ClassName("shopping_cart_badge")).Text;
            // Check if the item count in the cart is correct
            if (cartItemCount == "1")
            {
                Console.WriteLine("Item is added to the cart successfully.");
                cartIcon.Click();

            }
            else
            {
                Console.WriteLine("Item is not added to the cart.");
            
            }


        }

        public void FilterProducts()
        {

        }



    }
}
