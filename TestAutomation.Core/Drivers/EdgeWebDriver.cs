﻿using OpenQA.Selenium.Chrome;
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

namespace TestAutomation.Core.Drivers
{
    public class EdgeWebDriver : IEdgeWebDriver
    {


        public EdgeWebDriver()
        {

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

            return options;
        }
    }
}
