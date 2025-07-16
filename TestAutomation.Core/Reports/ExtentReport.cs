using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Abstraction;

namespace TestAutomation.Core.Reports
{
    public class ExtentReport : IExtentReport
    {
        IExtentFeatureReport _iextentFeatureReport;
        AventStack.ExtentReports.ExtentTest _feature, _scenario;

        public ExtentReport(IExtentFeatureReport iextentFeatureReport)
        {
            _iextentFeatureReport = iextentFeatureReport;
        }
        public void CreateFeature(string featureName)
        {
            _feature = _iextentFeatureReport.GetExtentReports().CreateTest(featureName);
        }

        public void CreateScenario(string scenarioName)
        {
            _scenario = _feature.CreateNode(scenarioName);
        }

        public void Pass(string msg, string base64)
        {

            if (base64 == null)
            {
                _scenario.Log(AventStack.ExtentReports.Status.Pass, msg);
            }
            else
            {
                _scenario.Log(AventStack.ExtentReports.Status.Pass, AventStack.ExtentReports.MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
            }
        }

        public void Fail(string msg, string base64)
        {
            if (base64 == null)
            {
                _scenario.Log(AventStack.ExtentReports.Status.Fail, msg);
            }
            else
            {
                _scenario.Log(AventStack.ExtentReports.Status.Fail, msg, AventStack.ExtentReports.MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
            }
        }
        public void Warning(string msg, string base64)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Warning, msg, AventStack.ExtentReports.MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
        }

        public void Error(string msg, string base64)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Error, msg, AventStack.ExtentReports.MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
        }

        public void Fatal(string msg, string base64)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Fatal, msg, AventStack.ExtentReports.MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
        }
    }
}
