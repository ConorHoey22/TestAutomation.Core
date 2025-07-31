using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
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

        }

        public void RemoveItemFromCart()
        {

        }

        public void FilterProducts()
        {

        }



    }
}
