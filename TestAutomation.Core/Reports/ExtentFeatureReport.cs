using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Abstraction;

namespace TestAutomation.Core.Reports
{
    public class ExtentFeatureReport : IExtentFeatureReport
    {
        private readonly IDefaultVariables _idefaultVariables;
        private AventStack.ExtentReports.ExtentReports _extentReports;

        public ExtentFeatureReport(IDefaultVariables idefaultVariables)
        {
            _idefaultVariables = idefaultVariables;
            _extentReports = new AventStack.ExtentReports.ExtentReports();

            InitiliazeExtentReport();
        }

        public void InitiliazeExtentReport()
        {
            string reportPath = _idefaultVariables.getExtentReport;

            string reportDirectory = Path.GetDirectoryName(reportPath);
            if (!Directory.Exists(reportDirectory))
            {
                Directory.CreateDirectory(reportDirectory);
            }


            var reporter = new ExtentHtmlReporter(reportPath);
            _extentReports = new AventStack.ExtentReports.ExtentReports();
            _extentReports.AttachReporter(reporter);
        }


        public AventStack.ExtentReports.ExtentReports GetExtentReports()
        {
            if (_extentReports == null)
            {
                Console.WriteLine("ExtentReports is not initialized. Please call InitiliazeExtentReport first.");
            }
            else
            {
                Console.WriteLine("ExtentReports is initialized successfully.");
            }

            return _extentReports;
        }

        public void FlushExtent()
        {
            _extentReports.Flush();

            if (File.Exists(_idefaultVariables.getExtentReport))
            {
                Console.WriteLine($"Extent report flushed successfully to {_idefaultVariables.getExtentReport}");
            }
            else
            {
                Console.WriteLine($"Extent report file not found at {_idefaultVariables.getExtentReport}. Please check the path.");
            }
        }
    }

}
