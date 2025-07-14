using System;
using OpenQA.Selenium;
using Reqnroll;
using TestAutomation.Test.Pages;

namespace TestAutomation.Test.Steps
{
    [Binding]
    public class LoginStepDefinitions
    {

        private readonly IWebDriver _driver;

        public LoginStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
        }


        [Given("the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");
        }

        [When("the user enters valid credentials")]
        public void WhenTheUserEntersValidCredentials()
        {
            Console.WriteLine("Entering valid credentials");
        }

        [Then("the user should be redirected to the dashboard")]
        public void ThenTheUserShouldBeRedirectedToTheDashboard()
        {
           Console.WriteLine("User redirected to the dashboard");
        }
    }
}
