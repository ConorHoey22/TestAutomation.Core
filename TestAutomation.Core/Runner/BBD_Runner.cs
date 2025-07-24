using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using NUnit.Framework.Internal;
using Reqnroll;
using Reqnroll.BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Abstraction;
using TestAutomation.Core.Container;
using TestAutomation.Core.Reports;

namespace TestAutomation.Core.Runner
{

    [Binding]
    public class BBD_Runner
    {
    
        private readonly IExtentReport _report;
      


        public BBD_Runner(IObjectContainer container)
        {
           _report = container.Resolve<IExtentReport>();
          


            if (_report == null)
            {
                Console.WriteLine("Extent Report is not initialized. Please check the configuration.");
            }
            else
            {
                Console.WriteLine("Extent Report is initialized successfully.");
            }
        }


        public static void BeforeFeature(FeatureContext featureContext, IObjectContainer container)
        {
            Console.WriteLine("HOOK - BeforeFeature started");

            try
            {
                var report = container.Resolve<IExtentReport>();
                report.CreateFeature(featureContext.FeatureInfo.Title);
                featureContext["iextentreport"] = report;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BeforeFeature: {ex.Message}");
            }
        }




    }
}
