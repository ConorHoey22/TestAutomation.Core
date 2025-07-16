using DotNetEnv;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Abstraction;

namespace TestAutomation.Core.Resources
{
    public class FrameworkSettings : IFrameworkSettings
    {

        public string DataSetLocation { get; set; }
        public string DownloadedLocation { get; set; }
        public string BrowserType { get; set; }
        public string BrowserVersion { get; set; }
        public string GridHubUrl { get; set; }
        public string LogLevel { get; set; }
        public string ExtentReportPortalUrl { get; set; }
        public string ExtentReportToPortal { get; set; }
        public bool StepScreenshot { get; set; }



        public void LoadConfiguration()
        {
           // Load .env variables
            string envPath = Path.Combine(AppContext.BaseDirectory, "frameworkSettings.env");

            if (!File.Exists(envPath))
            {
                Console.WriteLine($"Environment file not found at {envPath}. Please ensure it exists.");
                //Logging could be added here 

            }
            else
            {
                // Load the environment variables from the file 
                Env.Load(envPath);
                BrowserType = Environment.GetEnvironmentVariable("Browser");
                BrowserVersion = Environment.GetEnvironmentVariable("BROWSER_VERSION");
                GridHubUrl = Environment.GetEnvironmentVariable("GRID_HUB_URL");
                ExtentReportPortalUrl = Environment.GetEnvironmentVariable("EXTENT_REPORT_PORTAL_URL");
                ExtentReportToPortal = Environment.GetEnvironmentVariable("EXTENT_REPORT_TO_PORTAL");


            }
        }
    }
}
