using System;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using OpenQA.Selenium;
using Reqnroll;
using TestAutomation.Core.Pages;

namespace TestAutomation.Core.Steps
{
    [Binding]
    public class LoginStepDefinitions
    {

        private readonly LoginPage _loginPage;

        public LoginStepDefinitions(IWebDriver driver)
        {
            _loginPage = new LoginPage(driver);
        }

        [Given("the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            _loginPage.NavigateToLoginPage();
        }

        [When("the user enters valid credentials")]
        public void WhenTheUserEntersValidCredentials()
        {

            string username = "standard_user";
            string password = "secret_sauce";

            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
            _loginPage.ClickLogin();
        }

        [Then("the user should be redirected to the dashboard")]
        public void ThenTheUserShouldBeRedirectedToTheDashboard()
        {
            Console.WriteLine("User should be redirected to the dashboard.");
        }
    }
}
