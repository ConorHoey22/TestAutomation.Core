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
using TestAutomation.Core.Reports;
using TestAutomation.Core.Resources;

namespace TestAutomation.Core.Container
{
 
    public class ContainerConfig
    {
     
        public void ConfigureContainer(IObjectContainer container)
        {
            container.RegisterTypeAs<ChromeWebDriver, IChromeWebDriver>();
            container.RegisterTypeAs<EdgeWebDriver, IEdgeWebDriver>();
            container.RegisterTypeAs<ExtentReport, IExtentReport>();    
            container.RegisterTypeAs<ExtentFeatureReport,IExtentFeatureReport>();
            container.RegisterTypeAs<ApplicationSettings, IApplicationSettings>();
            container.RegisterTypeAs<FrameworkSettings,IFrameworkSettings>();

            // Register more dependencies here as needed
        }
    }
}
