using System;
using Bookstore.pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Bookstore.StepDefinitions
{
    [Binding]
    public class ProfileStepDefinitions
    {
        private IWebDriver driver;
        private ProfilePage profilePage;
        private LoginPage loginPage;
        public ProfileStepDefinitions()
        {
            driver = Hooks.Hooks.GetDriver();
            profilePage = new ProfilePage(driver);
            loginPage = new LoginPage(driver);
        }

        [When(@"the user navigates to the profile page")]
        public void WhenTheUserNavigatesToTheProfilePage()
        {
            profilePage.VerifyProfilepageUrl();
        }

        [Then(@"the profile page should display the logged-in user's username ""([^""]*)""")]
        public void ThenTheProfilePageShouldDisplayTheLogged_InUsersUsername(string username)
        {
            profilePage.VerifyUsername(username);
        }

        [Then(@"the ""([^""]*)"" button should be visible")]
        public void ThenTheButtonShouldBeVisible(string p0)
        {
            profilePage.VerifyLogoutButton();
        }

        [Then(@"the various buttons should be visible and clickable")]
        public void ThenTheVariousButtonsShouldBeVisibleAndClickable()
        {
            profilePage.VerifyLogoutButton();
            profilePage.VerifyGoToStoreButton();
            profilePage.VerifyDeleteAccButton();
            profilePage.VerifyDeleteAllBooksButton();

        }

        [Given(@"the user is not logged into the application")]
        public void GivenTheUserIsNotLoggedIntoTheApplication()
        {
            loginPage.GotoLoginPage();
        }

        [When(@"the user tries to access the profile page")]
        public void WhenTheUserTriesToAccessTheProfilePage()
        {
            loginPage.ClickProfile();
        }

        [Then(@"the user should  see the message""([^""]*)""")]
        public void ThenTheUserShouldSeeTheMessage(string message)
        {
            profilePage.VerifyMessage(message);
        }
    }
}
