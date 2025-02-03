using Bookstore.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Bookstore.Hooks
{
    [Binding]
    public  class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private static IWebDriver driver;
        private LoginPage loginPage;
        private ProfilePage profilePage;

        [BeforeScenario("@RequiresLogin",Order =2)] 
        public void BeforeScenarioWithTag()
        {
           

            loginPage = new LoginPage(driver);


            PerformLogin("nischal108", "Apple123@");
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            driver = new ChromeDriver();
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (driver != null)
            {
                driver.Quit(); // Close the browser
            }
            //TODO: implement logic that has to run after executing each scenario
        }
        public static  IWebDriver GetDriver()
        {
            return driver;
        }
        public void PerformLogin(string username,string password)
        {
            
            loginPage.GotoLoginPage();
            loginPage.VerifyLoginpageUrl();
            loginPage.VerifyTextPresent("Login");
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
            loginPage.ClickLoginButton(); 
            profilePage = new ProfilePage(driver);
            profilePage.VerifyProfilepageUrl();

        }
    }
}