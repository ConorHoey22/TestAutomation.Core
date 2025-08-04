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
    public class CartPage
    {

        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly ApplicationSettings _applicationSettings;
        private readonly FrameworkSettings _frameworkSettings;

        public CartPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _applicationSettings = new ApplicationSettings();
            _applicationSettings.LoadApplicationSettings(); // Load credentials and URL if needed
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

        }

        public void continueShoppingButton()
        {

        }

    }
}
