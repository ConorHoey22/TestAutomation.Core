using System;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using OpenQA.Selenium;
using Reqnroll;
using TestAutomation.Core.Abstraction;
using TestAutomation.Core.Pages;

namespace TestAutomation.Core.Steps
{
    [Binding]
    public class LoginStepDefinitions
    {

        IWebDriver driver;
        private readonly LoginPage _loginPage;

        public LoginStepDefinitions(IWebDriver driver)
        {

            _loginPage = new LoginPage(driver);
        }

        [Given("the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
        
            _loginPage.NavigateToLoginPage();
            Thread.Sleep(3000);
        }

        [When("the user enters valid credentials")]
        public void WhenTheUserEntersValidCredentials()
        {

            _loginPage.EnterUsername();
            _loginPage.EnterPassword();
            _loginPage.ClickLogin();
        }

        [Then("the user should be redirected to the dashboard")]
        public void ThenTheUserShouldBeRedirectedToTheDashboard()
        {
            Console.WriteLine("User should be redirected to the dashboard.");
        }
    }
}
