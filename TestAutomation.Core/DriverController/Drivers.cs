using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Abstraction;

namespace TestAutomation.Core.DriverController
{
    public class Drivers
    {
        IFrameworkSettings _frameworkSettings;
        IChromeWebDriver _ichromeWebDriver;
        IEdgeWebDriver _iedgeWebDriver;
        IWebDriver _iwebDriver;


        public Drivers(IChromeWebDriver ichromeWebDriver, IEdgeWebDriver iedgeWebDriver)
        {
            _ichromeWebDriver = ichromeWebDriver;
            _iedgeWebDriver = iedgeWebDriver;
        }

        public IWebDriver GetWebDriver()
        {
            if (_iwebDriver == null)
            {
                GetNewWebDriver();
            }
            return _iwebDriver;
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
