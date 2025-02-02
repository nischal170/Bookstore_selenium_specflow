using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Bookstore.pages
{
    public class ProfilePage
    {
        private readonly IWebDriver driver;
        private readonly CommonWebInteractions commonWebInteractions;
        string PageUrl = "https://demoqa.com/profile";
        private By LogOut = By.XPath("//button[contains(text(), 'Log out')]");
        private By GoToStoreBtn = By.XPath("//button[@id='gotoStore']");
        private By DelAccBtn = By.XPath("//button[contains(text(), 'Delete Account')]");
        private By DelAllBooks = By.XPath("//div[contains(@class, 'do')]//button[contains(text(), 'Delete All Books')]");
        private string[] TableColumns = { "Image", "Title", "Author", "Publisher","Action" };
        private By UsernameText=By.XPath("// div[@id='books-wrapper']/div[3]/label[2]");
        private By SearchBox = By.XPath("// input[@id='searchBox']");
        private By Messagetxt = By.XPath("//label[@id='notLoggin-label']");
        private By GotoBookstore = By.XPath("(//ul[@class='menu-list'])[6]/li[2]");

        public ProfilePage(IWebDriver  driver) {
            this.driver = driver;
            this.commonWebInteractions = new CommonWebInteractions(driver);

        }
        public void GotoProfileUrl()
        {
            driver.Url = PageUrl;
        }
        public void VerifyProfilepageUrl()
        {
            commonWebInteractions.VerifyPageUrl(PageUrl, "The login page URL is incorrect.");
        }
        public void VerifyUsername(string username)
        {
            commonWebInteractions.VerifyText(UsernameText, username);

        }
        public void VerifySearchField()
        {
            commonWebInteractions.CheckElementVisibility(SearchBox);

        }
        public void VerifyButtons()
        {
            commonWebInteractions.CheckElementVisibility(LogOut);
            commonWebInteractions.CheckButtonClickability(LogOut);

            commonWebInteractions.CheckElementVisibility(GoToStoreBtn);
            commonWebInteractions.CheckButtonClickability(GoToStoreBtn);

            commonWebInteractions.CheckElementVisibility(DelAccBtn);
            commonWebInteractions.CheckButtonClickability(DelAccBtn);

            commonWebInteractions.CheckElementVisibility(DelAllBooks);
            commonWebInteractions.CheckButtonClickability(DelAllBooks);
        }
        public void ClickLogoutButton()
        {
            commonWebInteractions.ClickButton(LogOut);

        }
        public void VerifyLogoutButton()
        {
            commonWebInteractions.CheckElementVisibility(LogOut);

        }
        public void VerifyMessage(string Message)
        {
            commonWebInteractions.VerifyText(Messagetxt,Message);

        }
        public void GoToBookstore()
        {
            commonWebInteractions.ClickButtonJs(GotoBookstore);
        }
    }
}
