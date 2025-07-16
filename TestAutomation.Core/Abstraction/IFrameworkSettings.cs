using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Core.Abstraction
{
    public interface IFrameworkSettings
    {
        string DataSetLocation { get; set; }
        string DownloadedLocation { get; set; }
        string BrowserType { get; set; }
        string BrowserVersion { get; set; }
        string GridHubUrl { get; set; }
        string LogLevel { get; set; }
        string ExtentReportPortalUrl { get; set; }
        string ExtentReportToPortal { get; set; }
        bool StepScreenshot { get; set; }

        void LoadConfiguration();
    }
}
