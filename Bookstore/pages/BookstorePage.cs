using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Bookstore.pages
{
    public class BookstorePage
    {
        private readonly IWebDriver driver;
        private readonly CommonWebInteractions commonWebInteractions;
        string PageUrl = "https://demoqa.com/books";

     
        // Locators 
        private By searchBox = By.XPath("//input[@id='searchBox']");
        private By emptyTable = By.XPath("//div[@class='rt-noData']");
        private By TableColumnsXpath = By.XPath("//div[@class='rt-table']/div[@class='rt-thead -header']/div/div/div[1]");
        private By BookTitles = By.XPath("//div[@class='rt-tbody']/div/div[1]/div[2]/div/span/a");//this shows only books in search result
        private By Publishers = By.XPath("//div[@class='rt-tbody']/div/div[1]/div[4][not(descendant::span)]");
        private By Authors = By.XPath("//div[@class='rt-tbody']/div/div[1]/div[3][not(descendant::span)]");

       

        public BookstorePage(IWebDriver driver)
        {
            this.driver = driver;
            this.commonWebInteractions = new CommonWebInteractions(driver);
        }
        
        public void VerifyBookstorePageUrl()
        {
            commonWebInteractions.VerifyPageUrl(PageUrl, "The login page URL is incorrect.");
        }
        
        public void VerifyEmptyTable(string ErrorMessage)
        {

            commonWebInteractions.VerifyText(emptyTable, ErrorMessage);
        }
        public void VerifyBookTitle(string BookName )
        {
            IReadOnlyCollection<IWebElement> BookNames = driver.FindElements(BookTitles);
            foreach (IWebElement element in BookNames)
            {
                string TextFromXpath = element.Text.Trim();
                Assert.AreEqual(BookName, TextFromXpath, $" Expected: '{BookName}', Actual: '{TextFromXpath}'");

            }
        }
        public void VerifyBookAuthor(string AuthorName)
        {
            IReadOnlyCollection<IWebElement> AuthorNames = driver.FindElements(Authors);
            foreach (IWebElement element in AuthorNames)
            {
                string TextFromXpath = element.Text.Trim();
                Assert.AreEqual(AuthorName, TextFromXpath, $" Expected: '{AuthorName}', Actual: '{TextFromXpath}'");

            }
        }
        public void VerifyBookPublisher(string PublisherName)
        {
            
            IReadOnlyCollection<IWebElement> PublishersNames = driver.FindElements(Publishers);
            foreach (IWebElement element in PublishersNames)
            {
                string TextFromXpath = element.Text.Trim();
                Assert.AreEqual(PublisherName, TextFromXpath, $" Expected: '{PublisherName}', Actual: '{TextFromXpath}'");

            }



        }
        public void TypeInSearch(string SearchQuery)
        {
            commonWebInteractions.Type(searchBox, SearchQuery);
        }

        public void VerifyTableColumnNames(string[] actualColumns)
        {
            commonWebInteractions.VerifyTableColumns(TableColumnsXpath, actualColumns);
            
        }
        public void VerifyTitleContains(string text)
        {
            IReadOnlyCollection<IWebElement> BooksName = driver.FindElements(BookTitles);
            foreach (IWebElement element in BooksName)
            {
                string TextFromXpath = element.Text.Trim().ToLower();
                Assert.IsTrue(TextFromXpath.Contains(text), $" Expected: '{text}', Actual: '{TextFromXpath}'");

            }

        }


    }
}
