using System;
using Bookstore.pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Bookstore.StepDefinitions
{
    [Binding]
    public class LogoutStepDefinitions
    {

        private IWebDriver driver;
        private ProfilePage profilePage;
        private LoginPage loginPage;
        public LogoutStepDefinitions()
        {
            driver = Hooks.Hooks.GetDriver();
            profilePage = new ProfilePage(driver);
            loginPage = new LoginPage(driver);

        }
        [Given(@"the user is on the profile page")]
        public void GivenTheUserIsOnTheProfilePage()
        {
            profilePage.VerifyProfilepageUrl();
        }

        [Then(@"the ""([^""]*)"" button should be visible and clickable")]
        public void ThenTheButtonShouldBeVisibleAndClickable(string p0)
        {
            profilePage.VerifyLogoutButton();
        }

        [When(@"the user clicks on the ""([^""]*)"" button")]
        public void WhenTheUserClicksOnTheButton(string p0)
        {
            profilePage.ClickLogoutButton();
        }

        [Then(@"the user should be redirected to the login page")]
        public void ThenTheUserShouldBeRedirectedToTheLoginPage()
        {
            loginPage.VerifyLoginpageUrl();
        }
    }
}
