using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Core.Abstraction
{
    public interface IDrivers
    {
        IWebDriver GetWebDriver();
        void StartFreshDriver();

        void CloseBrowser();

        string GetScreenshot();
    }
}
