using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Abstraction;
using TestAutomation.Core.Drivers;

namespace TestAutomation.Core.Container
{
 
    public class ContainerConfig
    {
        //public static IObjectContainer SetContainer(IObjectContainer iobjectContainer)
        //{
        //    iobjectContainer.RegisterTypeAs<ChromeWebDriver, IChromeWebDriver>();

        //    return iobjectContainer;
        //}

        public void ConfigureContainer(IObjectContainer container)
        {
            container.RegisterTypeAs<ChromeWebDriver, IChromeWebDriver>();
            // Register more dependencies here as needed
        }
    }
}
