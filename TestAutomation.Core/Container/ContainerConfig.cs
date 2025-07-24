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
using TestAutomation.Core.DIContainerConfig;

namespace TestAutomation.Core.Container
{
    [Binding]
    public class ContainerConfig
    {

        [BeforeTestRun]
        public static void BeforeTestRun(IObjectContainer iobjectcontainer)
        {
            Console.WriteLine("Registering dependencies...");

            iobjectcontainer.RegisterTypeAs<DefaultVariables, IDefaultVariables>();
            iobjectcontainer.RegisterTypeAs<ApplicationSettings, IApplicationSettings>();
            iobjectcontainer.RegisterTypeAs<FrameworkSettings, IFrameworkSettings>();
            iobjectcontainer.RegisterTypeAs<ExtentReport, IExtentReport>();
            iobjectcontainer.RegisterTypeAs<ExtentFeatureReport, IExtentFeatureReport>();
            iobjectcontainer.RegisterTypeAs<ChromeWebDriver, IChromeWebDriver>();
            iobjectcontainer.RegisterTypeAs<EdgeWebDriver, IEdgeWebDriver>();

            iobjectcontainer.RegisterTypeAs<Drivers, IDrivers>();

            Console.WriteLine("Dependencies registered successfully.");

            iobjectcontainer = CoreContainerConfig.GetContainer(iobjectcontainer);
            Console.WriteLine("Container configuration completed.");

            // Register more dependencies here as needed
        }
    }
}
