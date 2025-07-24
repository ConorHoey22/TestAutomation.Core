using Reqnroll.BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TestAutomation.Core.Abstraction;
using TestAutomation.Core.WebDrivers;
using TestAutomation.Core.DriverController;
using TestAutomation.Core.Params;
using TestAutomation.Core.Reports;
using TestAutomation.Core.Resources;

namespace TestAutomation.Core.DIContainerConfig
{
    public class CoreContainerConfig
    {
        public static IObjectContainer GetContainer(IObjectContainer iobjectContainer)
        {

            return iobjectContainer;
        }
    }
}
