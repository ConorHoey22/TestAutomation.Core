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
using TestAutomation.Core.WebDrivers;
using TestAutomation.Core.Reports;
using TestAutomation.Core.Resources;
using TestAutomation.Core.DriverController;
using TestAutomation.Core.Params;

namespace TestAutomation.Core.Container
{
 
    public class ContainerConfig
    {
     
        public void ConfigureContainer(IObjectContainer container)
        {
          
            container.RegisterTypeAs<ChromeWebDriver, IChromeWebDriver>();
            container.RegisterTypeAs<EdgeWebDriver, IEdgeWebDriver>();
            container.RegisterTypeAs<DefaultVariables, IDefaultVariables>();
            container.RegisterTypeAs<ExtentReport, IExtentReport>();
            container.RegisterTypeAs<ExtentFeatureReport,IExtentFeatureReport>();
            container.RegisterTypeAs<ApplicationSettings, IApplicationSettings>();
            container.RegisterTypeAs<FrameworkSettings, IFrameworkSettings>();


            container.RegisterTypeAs<Drivers, IDrivers>();



            // Register more dependencies here as needed
        }
    }
}
