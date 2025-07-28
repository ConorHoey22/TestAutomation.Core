using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Resources;
using SeleniumExtras.WaitHelpers;

namespace TestAutomation.Core.Pages
{
        public class LoginPage
        {
            private readonly IWebDriver _driver;
            private readonly WebDriverWait _wait;
            private readonly ApplicationSettings _applicationSettings;
            private readonly FrameworkSettings _frameworkSettings;

        //private const string LoginUrl = "https://www.saucedemo.com/v1/";


            public LoginPage(IWebDriver driver)
            {
                _driver = driver ?? throw new ArgumentNullException(nameof(driver));
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                _applicationSettings = new ApplicationSettings();
                _applicationSettings.LoadApplicationSettings(); // Load credentials and URL if needed
            }

            private IWebElement UsernameInput => _driver.FindElement(By.Id("user-name"));
            private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
            private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));

            private IWebElement ProductPage => _driver.FindElement(By.Id("inventory_container"));

            public void NavigateToLoginPage()
            {
                _driver.Navigate().GoToUrl(_applicationSettings.url);
            }


            public void EnterUsername()
            {
                UsernameInput.Clear();
                UsernameInput.SendKeys(_applicationSettings.username);
            }

            public void EnterPassword()
            {
                PasswordInput.Clear();
                PasswordInput.SendKeys(_applicationSettings.password);
            }

            public bool IsUserOnDashboard()
            {
                try
                {
                    _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='inventory_container']")));
                    return true;
                }
                catch (WebDriverTimeoutException)
                {
                    return false;
                }
            }

            public bool LoginValidationAppears()
            {
                try
                {
                    return _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h3[data-test='error']"))).Displayed;
                }
                catch (WebDriverTimeoutException)
                {
                    return false;
                }

            }

            public void EnterInvalidUsername()
            {
                UsernameInput.Clear();
                UsernameInput.SendKeys("user.name");
            }

            public void EnterInvalidPassword()
            {
                PasswordInput.Clear();
                PasswordInput.SendKeys("test11");
            }


            public void ClickLogin()
            {
                    LoginButton.Click();
            }
      
            public void LoginAs(string username, string password)
                {
                        NavigateToLoginPage();
                        EnterUsername();
                        EnterPassword();
                        ClickLogin();
                }
            }
}

