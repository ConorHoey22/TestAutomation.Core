using Reqnroll;
using OpenQA.Selenium;
using Reqnroll.BoDi;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using TestAutomation.Core.Abstraction;
using TestAutomation.Core.Container;
using System.Security.AccessControl;
using TestAutomation.Core.Runner;
using TestAutomation.Core.Reports;
using WebDriverManager;
using TestAutomation.Core.DriverController;


namespace TestAutomation.Core.BBD_Hooks
{
    [Binding]
    public class BBD_Hooks
    {
        IDrivers _idrivers;
        IWebDriver _iwebDriver;

        private readonly IObjectContainer _container;
        private readonly BBD_Runner _runner;


        public BBD_Hooks(IObjectContainer container, IDrivers idriver, ScenarioContext scenarioContext, FeatureContext featureContext)
        {

            _container = container;
          
        }

        [BeforeTestRun]
        public static void BeforeTestRun(IObjectContainer container)
        {
            var config = new ContainerConfig();
            config.ConfigureContainer(container);

        }


        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext , IObjectContainer container )
        {
            try
            {
                var extentFeatureReport = container.Resolve<IExtentFeatureReport>();

                IExtentReport extentReport = new ExtentReport(extentFeatureReport);
                featureContext["iextentreport"] = extentReport;
            }
            catch (Exception ex)
            {
                 Console.WriteLine("Exception in BeforeFeature: " + ex.Message + ex.StackTrace);
            }
        }



        [BeforeScenario(Order = 2)]
        public void BeforeScenario(IObjectContainer iobjectcontainer, ScenarioContext sc, FeatureContext fc)
        {

            try
            {
                _idrivers = iobjectcontainer.Resolve<IDrivers>();

                //Open a Fresh rowser for each scenario
                _idrivers.StartFreshDriver();

                var extentReport = (IExtentReport)fc["iextentreport"];
                string featureName = fc.FeatureInfo.Title;

                extentReport.CreateFeature(fc.FeatureInfo.Title);
                extentReport.CreateScenario(sc.ScenarioInfo.Title);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception in BeforeScenario: " + ex.Message + ex.StackTrace);
            }
        }


        [AfterStep]
        public void AfterStep(IObjectContainer iobjectContainer , ScenarioContext scenarioContext, FeatureContext fc, IFrameworkSettings frameworkSettings)
        {
            try
            {
                _idrivers = iobjectContainer.Resolve<IDrivers>();


                IExtentReport extentReport = (IExtentReport)fc["iextentreport"];

                if(_idrivers == null)
                {
                    throw new InvalidOperationException("IDrivers is not initialized. Please check the configuration.");
                }

                if (scenarioContext.TestError != null)
                {
                    string base64 = null;
                    base64 = _idrivers.GetScreenshot();
                    extentReport.Fail(scenarioContext.StepContext.StepInfo.Text, base64);
                }
                else
                {
                    string base64 = null;

                    Thread.Sleep(1000); // Wait for the page to load completely
                    base64 = _idrivers.GetScreenshot();

                    extentReport.Pass(scenarioContext.StepContext.StepInfo.Text, base64);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in AfterStep: " + ex.Message + ex.StackTrace);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                var extentFeatureReport = _container.Resolve<IExtentFeatureReport>();
                extentFeatureReport.FlushExtent();

                Thread.Sleep(1000); // Wait for the report to flush completely

                // Close the browser after each scenario

                if(_idrivers != null)
                {
                    _idrivers.CloseBrowser();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in AfterScenario: " + ex.Message + ex.StackTrace);
            }

        }



    }
}