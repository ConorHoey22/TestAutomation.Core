using System;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NuGet.Frameworks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using SeleniumExtras.WaitHelpers;
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

            //if (!_loginPage.IsUserOnDashboard())
            //{
            //    Assert.Fail();
            //}
            //else
            //{
            //    Assert.Pass();
            //}

            Assert.IsTrue(_loginPage.IsUserOnDashboard(), "User was not redirected to the dashboard.");

        }
    




        //Invalid Steps 
        [When("the user enters invalid credentials")]
        public void WhenTheUserEntersInvalidCredentials()
        {
            _loginPage.EnterInvalidUsername();
            _loginPage.EnterInvalidPassword();
            _loginPage.ClickLogin();
        }

        [Then("validation should appear")]
        public void ThenValidationShouldAppear()
        {
           Assert.IsTrue(_loginPage.LoginValidationAppears(), "Validation message did not appear for invalid credentials.");
        }

    }
}
