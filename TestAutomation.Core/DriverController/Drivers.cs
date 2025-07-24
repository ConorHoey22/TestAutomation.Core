using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Abstraction;
using TestAutomation.Core.WebDrivers;

namespace TestAutomation.Core.DriverController
{
    [Binding]
    public class Drivers : IDrivers
    {


        IFrameworkSettings _frameworkSettings;
        IChromeWebDriver _ichromeWebDriver;
        IEdgeWebDriver _iedgeWebDriver;
        IWebDriver _iwebDriver;


        public Drivers(IChromeWebDriver ichromeWebDriver, IEdgeWebDriver iedgeWebDriver, IFrameworkSettings iframeworksettings)
        {
            _ichromeWebDriver = ichromeWebDriver;
            _iedgeWebDriver = iedgeWebDriver;
            _frameworkSettings = iframeworksettings;
        }

        public IWebDriver GetWebDriver()
        {
            if (_iwebDriver == null)
            {
                GetNewWebDriver();
            }
            return _iwebDriver;
        }

        public void StartFreshDriver()
        {
            if (_iwebDriver != null)
            {
                try
                {
                    _iwebDriver.Quit();
                    _iwebDriver.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception while closing the browser: " + ex.Message);
                }
               
                _iwebDriver = new ChromeDriver(); // Default to ChromeDriver if not set
            }

        }
        public void GetNewWebDriver()
        {

            switch (_frameworkSettings.BrowserType.ToLower())
            {
                case "chrome":
                    _iwebDriver = _ichromeWebDriver.CreateDriver();
                    break;
                case "edge":
                    _iwebDriver = _iedgeWebDriver.CreateDriver();
                    break;
                default:
                    _iwebDriver = _ichromeWebDriver.CreateDriver();
                    break;

            }


        }

        public void CloseBrowser()
        {
            _iwebDriver.Quit();
        }

        public string GetScreenshot()
        {
            return ((ITakesScreenshot)GetWebDriver()).GetScreenshot().AsBase64EncodedString;
        }
    }

}
