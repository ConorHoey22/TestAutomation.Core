using AngleSharp;
using Reqnroll;
using Reqnroll.BoDi;
using OpenQA.Selenium;
using TestAutomation.Core.Container;
using OpenQA.Selenium.Chrome;
using TestAutomation.Core.Abstraction;

namespace TestAutomation.Core.Hooks
{
    [Binding]
    public class BBD_Hooks
    {
        private readonly IObjectContainer _container;
        private IWebDriver _driver;

        public BBD_Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            new ContainerConfig().ConfigureContainer(_container);

            var chromeDriver = _container.Resolve<IChromeWebDriver>();
            _driver = chromeDriver.CreateDriver();

            _container.RegisterInstanceAs<IWebDriver>(_driver);


        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver?.Quit();
        }
    }
}
