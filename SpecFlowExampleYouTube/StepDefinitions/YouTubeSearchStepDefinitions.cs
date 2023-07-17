using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace WebDriverExample4.StepDefinitions
{
    [Binding]
    public class YouTubeSearchStepDefinitions
    {

        private IWebDriver driver;

        public YouTubeSearchStepDefinitions(IWebDriver driver)
        {
            //Assign the web Driver
            this.driver = driver;
        }

        [Given(@"I am on YouTube website")]
        public void GivenIAmOnYouTubeWebsite()
        {
            // driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.youtube.com/");
        }

        [When(@"I type ""([^""]*)"" in the search field")]
        public void WhenITypeInTheSearchField(string searchText)
        {
            IWebElement searchField = driver.FindElement(By.XPath("//*[@name='search_query']"));
            searchField.SendKeys(searchText);
        }

        [When(@"I click search button")]
        public void WhenIClickSearchButton()
        {
            IWebElement searchButton = driver.FindElement(By.XPath("//*[@id=\"search-icon-legacy\"]/yt-icon"));
            searchButton.Click();
        }
        
        [Then(@"Search results should be is displayed")]
        public void ThenSearchResultsShouldBeIsDisplayed()
        {
            IWebElement searchResults = driver.FindElements(By.XPath("//*[@id='video-title']")).First();
            Assert.IsTrue(searchResults.Displayed);

            //driver.Quit();
        }

    }
}
