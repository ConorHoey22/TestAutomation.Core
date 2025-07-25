﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll.BoDi;
using System;
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
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            //     options.AddArgument("--headless"); // Uncomment if you want to run in headless mode ( Used for CI setup) 

            options.AddUserProfilePreference("download.default_directory", _frameworkSettings.DataSetLocation);
            return options;
        }

    }

}
 

