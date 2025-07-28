using Reqnroll;
using OpenQA.Selenium;
using Reqnroll.BoDi;
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
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports;


namespace TestAutomation.Core.BBD_Hooks
{
    [Binding]
    public class BBD_Hooks
    {
        IDrivers _idrivers;
        private IWebDriver _iwebDriver;


        private readonly IObjectContainer _container;
        private readonly BBD_Runner _runner;


        public BBD_Hooks(IObjectContainer container, ScenarioContext scenarioContext, FeatureContext featureContext)
        {

            _container = container;
            
            _runner = _container.Resolve<BBD_Runner>();

        }


     
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext, IObjectContainer container)
        {
            Console.WriteLine("HOOK - BeforeFeature started");

            try
            {
                // Ensure the container is not null
                if (container == null)
                {
                    throw new ArgumentNullException(nameof(container), "The container is null.");
                }
                // Debug: Check if IExtentFeatureReport is registered
                Console.WriteLine("Attempting to resolve IExtentFeatureReport...");
                var extentFeatureReport = container.Resolve<IExtentFeatureReport>();
                Console.WriteLine("IExtentFeatureReport resolved successfully.");

    
                if (extentFeatureReport == null)
                {
                    throw new InvalidOperationException("Failed to resolve IExtentFeatureReport. Ensure it is registered in the container.");
                }

                Console.WriteLine("HOOK - 1 started");

                // Create ExtentReport
                IExtentReport extentReport = new ExtentReport(extentFeatureReport);
                Console.WriteLine("HOOK - 2 started");

                // Store in FeatureContext
                featureContext["iextentreport"] = extentReport;
            }
            catch (Exception ex)
            {
                Console.WriteLine("HOOK - 3 started");
                Console.WriteLine("Exception in BeforeFeature: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
            }
        }



        [BeforeScenario(Order = 2)]
        public void BeforeScenario(IObjectContainer iobjectcontainer, ScenarioContext sc, FeatureContext fc)
        {
            Console.WriteLine("HOOK - BeforeScenario started");
            try
            {
                _idrivers = iobjectcontainer.Resolve<IDrivers>();

                //Open a Fresh Browser for each scenario
                _idrivers.StartFreshDriver();

                _iwebDriver = _idrivers.GetWebDriver();
                _container.RegisterInstanceAs<IWebDriver>(_iwebDriver);

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

            Console.WriteLine("HOOK - AfterStep started");

            var stepInfo = scenarioContext.StepContext.StepInfo;
            var stepText = stepInfo.Text;
            var stepKeyword = stepInfo.StepDefinitionType.ToString(); // Given, When, Then, etc.




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

            Console.WriteLine("HOOK - AfterScenario started");
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