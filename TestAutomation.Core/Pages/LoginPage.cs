using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Core.Pages
{
        public class LoginPage
        {
            private readonly IWebDriver _driver;
            private const string LoginUrl = "https://www.saucedemo.com/v1/";

            private const string username = "standard_user";
            private const string password = "secret_sauce";

            public LoginPage(IWebDriver driver)
            {
                _driver = driver;
            }

            private IWebElement UsernameInput => _driver.FindElement(By.Id("user-name"));
            private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
            private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));


            public void NavigateToLoginPage()
            {
                _driver.Navigate().GoToUrl(LoginUrl);
            }


            public void EnterUsername(string username)
            {
                UsernameInput.Clear();
                UsernameInput.SendKeys(username);
            }

            public void EnterPassword(string password)
            {
                PasswordInput.Clear();
                PasswordInput.SendKeys(password);
            }

            public void ClickLogin()
            {
                LoginButton.Click();
            }

            public void LoginAs(string username, string password)
            {
                NavigateToLoginPage();
                EnterUsername(username);
                EnterPassword(password);
                ClickLogin();
            }
        }
}

