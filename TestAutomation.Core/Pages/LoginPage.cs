using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Resources;

namespace TestAutomation.Core.Pages
{
        public class LoginPage
        {
            private readonly IWebDriver _driver;
            private readonly ApplicationSettings _applicationSettings;
            private readonly FrameworkSettings _frameworkSettings;

        //private const string LoginUrl = "https://www.saucedemo.com/v1/";


        public LoginPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));

            _applicationSettings = new ApplicationSettings();
            _applicationSettings.LoadApplicationSettings(); // Load credentials and URL if needed
        }

            private IWebElement UsernameInput => _driver.FindElement(By.Id("user-name"));
            private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
            private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));


            public void NavigateToLoginPage()
            {
            //  _driver.Navigate().GoToUrl(_applicationSettings.url);

            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
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

