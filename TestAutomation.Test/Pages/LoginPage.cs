using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Test.Pages
{
    public class LoginPage
    {
  
            IWebDriver _driver;

            public LoginPage(IWebDriver driver)
            {
                _driver = driver;
            }

            private IWebElement UsernameInput => _driver.FindElement(By.Id("username"));
            private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
            private IWebElement LoginButton => _driver.FindElement(By.Id("login"));

            public void NavigateToLoginPage()
            {
                _driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");
            }

            public void EnterUsername(string username) => UsernameInput.SendKeys(username);
            public void EnterPassword(string password) => PasswordInput.SendKeys(password);
            public void ClickLogin() => LoginButton.Click();
        
    }
}
