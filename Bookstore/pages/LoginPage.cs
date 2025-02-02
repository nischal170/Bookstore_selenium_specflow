using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using OpenQA.Selenium;

namespace Bookstore.pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly CommonWebInteractions commonWebInteractions;
        string PageUrl = "https://demoqa.com/login";
        // Locators 
        private By LoginText = By.XPath("//div/h1[@class='text-center']");
        private By UserNameField = By.XPath("//input[@id='userName']");
        private By PasswordField = By.XPath("//input[@id='password']");
        private By loginButton = By.XPath("//button[@id='login']");
        private By errorMessage = By.XPath("//p[@id='name']");
        private By Profile = By.XPath("(//ul[@class='menu-list'])[6]/li[3]");

        public LoginPage(IWebDriver driver) {
            this.driver = driver;
            this.commonWebInteractions = new CommonWebInteractions(driver);
        }
       public void GotoLoginPage()
        {
            driver.Url = PageUrl;
        }

        public void VerifyLoginpageUrl()
        {
            commonWebInteractions.VerifyPageUrl(PageUrl, "The login page URL is incorrect.");
        }

        public void VerifyTextPresent(string text)
        {
            commonWebInteractions.VerifyText(LoginText, text);
        }
        
        public void EnterUsername(string username)
        {
            commonWebInteractions.Type(UserNameField, username);
        }
        public void EnterPassword(string Password)
        {
            commonWebInteractions.Type(PasswordField, Password);
        }
        public void ClickLoginButton()
        {
            commonWebInteractions.ClickButtonJs(loginButton);
   
        }

        public void VerifyMessage(string message)
        {
            commonWebInteractions.VerifyText(errorMessage, message);

        }
        public void ClickProfile()
        {
            commonWebInteractions.ClickButtonJs(Profile);
        }

    }
}
