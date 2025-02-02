using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;// for assertion
using OpenQA.Selenium;// for IWebDriver
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Support.UI; //for selectelement
using SeleniumExtras.WaitHelpers;

namespace Bookstore.pages
{
    public class CommonWebInteractions
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public CommonWebInteractions(IWebDriver driver,int timeoutInSeconds=10)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)); //explicit wait
        }
        public void VerifyPageUrl(string expectedUrl, string errorMessage = "Page URL mismatch")
        {
            wait.Until(driver => driver.Url == expectedUrl);
            string actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl, errorMessage);
        }
        // verify the text is contained in that xpath
        public void VerifyText(By locator, string expectedText, string errorMessage = "Text mismatch in element")
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5)); //using explicit wait
            IWebElement errorMessageElement = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            string actualText = errorMessageElement.Text.Trim();
            Assert.AreEqual(expectedText, actualText, $"{errorMessage}. Expected: '{expectedText}', Actual: '{actualText}'");

        }
        // Click on an element
        public void ClickButton(By locator)
        { 
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        
            
        }
        public void ClickButtonJs(By locator)  //javascript click if overlayprevent click
        {
            IWebElement element = driver.FindElement(locator);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }


        // Enter text into an input field
        public void Type (By locator, string text)
        {
            IWebElement Element = wait.Until(driver => driver.FindElement(locator));
            Element.Clear();
            Element.SendKeys(text);
        }

        // Select an option from a dropdown by visible text
        public void SelectDropdownByText(By locator, string text)
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(locator));
            dropdown.SelectByText(text);
        }

        // Select an option from a dropdown by value
        public void SelectDropdownByValue(By locator, string value)
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(locator));
            dropdown.SelectByValue(value);
        }

        // Select a radio button
        public void SelectRadioButton(By locator)
        {
            IWebElement radioButton = driver.FindElement(locator);
            if (!radioButton.Selected)
            {
                radioButton.Click();
            }
        }

        // Check a checkbox
        public void CheckCheckbox(By locator)
        {
            IWebElement checkbox = driver.FindElement(locator);
            if (!checkbox.Selected)
            {
                checkbox.Click();
            }
        }

        // Uncheck a checkbox
        public void UncheckCheckbox(By locator)
        {
            IWebElement checkbox = driver.FindElement(locator);
            if (checkbox.Selected)
            {
                checkbox.Click();
            }
        }

        // check if a button contains text
        public bool ButtonContainsText (By locator,string text)
        {
            IWebElement  button = driver.FindElement(locator);
            if (button.Text == text)
            {
                return true;
            }
            else return false;
        }

        
        public bool IsElementInteractable(By locator)
        {
            try
            {
                IWebElement element = driver.FindElement(locator);
                return element.Displayed && element.Enabled;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void CheckOverlapping(By locator)
        {
            IWebElement blockingElement = driver.FindElement(locator);
            Console.WriteLine("Blocking element: " + blockingElement.TagName);

        }
        public void VerifyTableColumns(By locator,string[] expectedColumns)
        {
            var columnElements = driver.FindElements(locator);
            Assert.AreEqual(expectedColumns.Length, columnElements.Count,$"Expected {expectedColumns.Length} columns, but found {columnElements.Count}");
            for (int i = 0; i < columnElements.Count; i++)
            {
                string actualText = columnElements[i].Text.Trim();
                string expectedText = expectedColumns[i].Trim();
                Assert.AreEqual(expectedText, actualText,$"Column text mismatch at index {i}. Expected: '{expectedText}', Actual: '{actualText}'");
            }

        }

        public void CheckElementVisibility(By locator)
        {
            IWebElement Element = wait.Until(driver=>driver.FindElement(locator));
            Assert.IsTrue(Element.Displayed, "Element is not visible");

        }

        public void CheckButtonClickability(By locator)
        {
            IWebElement Element = wait.Until(driver => driver.FindElement(locator));
            Assert.IsTrue(Element.Enabled, "Element is not visible");

        }

       
    }




    }

