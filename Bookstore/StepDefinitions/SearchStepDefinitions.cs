using System;
using System.Security.Policy;
using System.Xml.Linq;
using Bookstore.pages;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Bookstore.StepDefinitions
{
    [Binding]
    public class SearchStepDefinitions
    {
        private IWebDriver driver;
        private ProfilePage profilePage;
        private BookstorePage searchPage;
        public SearchStepDefinitions()
        {
            driver = Hooks.Hooks.GetDriver();
            profilePage = new ProfilePage(driver);
            searchPage = new BookstorePage(driver);
        }
        [Given(@"the user is on the books search page")]
        public void GivenTheUserIsOnTheBooksSearchPage()
        {
            profilePage.GoToBookstore();
            searchPage.VerifyBookstorePageUrl();
        }

        [When(@"The user enters  the book by the title ""([^""]*)""")]
        public void WhenTheUserEntersTheBookByTheTitle(string title)
        {
            searchPage.TypeInSearch(title);
        }

        [Then(@"The user should see the book's title ""([^""]*)"" in the search result")]
        public void ThenTheUserShouldSeeTheBooksTitleInTheSearchResult(string title)
        {
            searchPage.VerifyBookTitle(title);
        }

        [Then(@"each book result should display the following columns:")]
        public void ThenEachBookResultShouldDisplayTheFollowingColumns(Table table)
        {
            string[] columnNames = table.Header.ToArray();
            searchPage.VerifyTableColumnNames(columnNames);
        }

        [When(@"the user enters an author's name ""([^""]*)"" in the search bar")]
        public void WhenTheUserEntersAnAuthorsNameInTheSearchBar(string Author)
        {
            searchPage.TypeInSearch(Author);
        }

        [Then(@"the user should see a list of books written by the author""([^""]*)""")]
        public void ThenTheUserShouldSeeAListOfBooksWrittenByTheAuthor(string Author)
        {
            searchPage.VerifyBookAuthor(Author);
        }

        [When(@"the user enters a partial book title ""([^""]*)"" in the search bar")]
        public void WhenTheUserEntersAPartialBookTitleInTheSearchBar(string partial_title)
        {
            searchPage.TypeInSearch(partial_title);
        }

        [Then(@"the user should see books matching the partial title ""([^""]*)""")]
        public void ThenTheUserShouldSeeBooksMatchingThePartialTitle(string partial_title)
        {
            string LowerCaseTitle = partial_title.ToLower();
            searchPage.VerifyTitleContains(LowerCaseTitle);
        }

        [When(@"the user enters an publisher's name ""([^""]*)"" in the search bar")]
        public void WhenTheUserEntersAnPublishersNameInTheSearchBar(string p0)
        {
            searchPage.TypeInSearch(p0);
        }

        [Then(@"the user should see a list of books written by the Publisher ""([^""]*)""")]
        public void ThenTheUserShouldSeeAListOfBooksWrittenByThePublisher(string publisher)
        {
            searchPage.VerifyBookPublisher(publisher);
        }

        [When(@"the user enters ""([^""]*)"" in the search bar and clicks the search button")]
        public void WhenTheUserEntersInTheSearchBarAndClicksTheSearchButton(string query)
        {
            searchPage.TypeInSearch(query);
        }

        [Then(@"the user should see a message saying ""([^""]*)""")]
        public void ThenTheUserShouldSeeAMessageSaying(string message)
        {
            searchPage.VerifyEmptyTable(message);
        }
    }
}
