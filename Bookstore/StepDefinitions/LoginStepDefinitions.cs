using System;
using Bookstore.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Bookstore.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private ProfilePage profilePage;
        public LoginStepDefinitions()
        {
            driver = Hooks.Hooks.GetDriver();
            loginPage = new LoginPage(driver);
        }
        [Given(@"The user navigates to the Book Store login page")]
        public void GivenTheUserNavigatesToTheBookStoreLoginPage()
        {
            
            loginPage.GotoLoginPage();
            loginPage.VerifyLoginpageUrl();
            loginPage.VerifyTextPresent("Login");// this verifies the "Login" text present as a header in the login page 
         

        }

        [When(@"The user enters valid username ""([^""]*)""  and password ""([^""]*)""")]
        public void WhenTheUserEntersValidUsernameAndPassword(string username, string password)
        {
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
        }

        [When(@"The user clicks the login button")]
        public void WhenTheUserClicksTheLoginButton()
        {   
            loginPage.ClickLoginButton();
            
        }

        [Then(@"The user should be logged in successfully")]
        public void ThenTheUserShouldBeLoggedInSuccessfully()
        {
            profilePage=new ProfilePage(driver);
            profilePage.VerifyProfilepageUrl();
        }

        [When(@"The user enters invalid ""([^""]*)"" and invalid  ""([^""]*)""")]
        public void WhenTheUserEntersInvalidAndInvalid(string username, string password)
        {
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
            
        }

        [Then(@"The user should see an error message ""([^""]*)""")]
        public void ThenTheUserShouldSeeAnErrorMessage(string message)
        {
            loginPage.VerifyMessage(message);
        }

        [When(@"The user enters blank ""([^""]*)""  and ""([^""]*)""")]
        public void WhenTheUserEntersBlankAnd(string username, string password)
        {
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
        }

        [Then(@"The user shouldn't be able to login")]
        public void ThenTheUserShouldntBeAbleToLogin()
        {
            loginPage.VerifyLoginpageUrl();
        }
    }
}
