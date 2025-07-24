using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using TestAutomation.Core.Abstraction;
using TestAutomation.Core.Resources;
using System.ComponentModel;
using Reqnroll.BoDi;

namespace TestAutomation.Core.WebDrivers
{
    public class EdgeWebDriver : IEdgeWebDriver
    {
        IFrameworkSettings _frameworkSettings;
        IApplicationSettings _applicationSettings;

        IObjectContainer _container;

        public EdgeWebDriver(IObjectContainer container)
        {
            _frameworkSettings = container.Resolve<IFrameworkSettings>();
        }

        public IWebDriver CreateDriver()
        {
            // Set up Edge driver using WebDriverManager
            new DriverManager().SetUpDriver(new EdgeConfig());

            // Create and return the Edge WebDriver
            IWebDriver driver = new EdgeDriver(GetOptions());
            driver.Manage().Window.Maximize();
            return driver;
        }

        public EdgeOptions GetOptions()
        {
            var options = new EdgeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");

            // Uncomment to run in headless mode (e.g., CI/CD)
            // options.AddArgument("--headless");
            options.AddUserProfilePreference("download.default_directory", _frameworkSettings.DataSetLocation);

            return options;
        }
    }
}
