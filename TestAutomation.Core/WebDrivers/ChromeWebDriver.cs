using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Chrome;
using Reqnroll.BoDi;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Abstraction;
using WebDriverManager.DriverConfigs.Impl;

namespace TestAutomation.Core.WebDrivers
{
    public class ChromeWebDriver : IChromeWebDriver
    {
        IFrameworkSettings _frameworkSettings;
        IApplicationSettings _applicationSettings;

        IObjectContainer _container;

        public ChromeWebDriver(IObjectContainer container)
        {
            _frameworkSettings = container.Resolve<IFrameworkSettings>();
        }

        public IWebDriver CreateDriver()
        {

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver(GetOptions());
            driver.Manage().Window.Maximize();
            return driver;
        }


        public ChromeOptions GetOptions()
        {
            var options = new ChromeOptions();
  



            // Disable password saving UI
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            options.AddUserProfilePreference("credentials_enable_service", false);

            options.AddArgument("--start-maximized");


            //// Disable notifications
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);

            //// Set download directory
            //options.AddUserProfilePreference("download.default_directory", _frameworkSettings.DataSetLocation);

            return options;

        }

    }

}
 

