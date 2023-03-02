using OpenQA.Selenium;
using ProjectStructure.Driver;
using SeleniumExtras.WaitHelpers;

namespace ProjectStructure.Pages
{
    public class SearchResultPage : BasePage
    {
        private readonly By FormLocator = By.Id("advsearchform");

        private readonly By SearchBoxLocator = By.XPath("//*[@class='searchbar_left']/child::input[@id='realterm']");

        private readonly By NamesLocator = By.XPath("//*[@id='search_resultsRows']/descendant::span[@class='title']");

        private readonly By PlatformContainerLocator = 
            By.XPath("//*[@id='search_resultsRows']/descendant::div[contains(@class, 'ellipsis')]/div");

        private readonly By ReleaseDatesLocator = 
            By.XPath("//*[@id='search_resultsRows']/descendant::div[contains(@class, 'search_released')]");

        private readonly By ReviewSummariesLocator =
            By.XPath("//*[@id='search_resultsRows']/descendant::span[contains(@class, 'review_summary')]");

        private readonly By PricesLocator =
            By.XPath("//*[@id='search_resultsRows']/descendant::div[contains(@class, 'price') and not(contains(@class, 'discount'))]");

        public SearchResultPage() : base() { }

        public IWebElement Form => base.WaitAndFindElement(FormLocator);
   
        public IWebElement SearchBox => base.WaitAndFindElement(SearchBoxLocator);

        public IReadOnlyCollection<IWebElement> Names
        {
            get
            {
                base.Wait.Until(ExpectedConditions.ElementExists(NamesLocator));
                return Singleton.Driver().FindElements(NamesLocator);
            }
        }
    
        public IReadOnlyCollection<IWebElement> PlatformContainer
        {
            get 
            {
                base.Wait.Until(ExpectedConditions.ElementExists(PlatformContainerLocator));
                return Singleton.Driver().FindElements(PlatformContainerLocator);
            }
        }
    
        public IReadOnlyCollection<IWebElement> ReleaseDates
        {
            get 
            {
                base.Wait.Until(ExpectedConditions.ElementExists(ReleaseDatesLocator));
                return Singleton.Driver().FindElements(ReleaseDatesLocator);
            }
        }

        public IReadOnlyCollection<IWebElement> ReviewSummaries
        {
            get
            {
                base.Wait.Until(ExpectedConditions.ElementExists(ReviewSummariesLocator));
                return Singleton.Driver().FindElements(ReviewSummariesLocator);
            }
        }

        public IReadOnlyCollection<IWebElement> Prices
        {
            get
            {
                base.Wait.Until(ExpectedConditions.ElementExists(PricesLocator));
                return Singleton.Driver().FindElements(PricesLocator);
            }
        }
        
        public IReadOnlyCollection<IWebElement> GetPlatformElementsOf(int resultNumber)
        {
            if (resultNumber < 1 && resultNumber > this.PlatformContainer.Count)
            {
                throw new ArgumentException($"Invalid search result number: {resultNumber}!");
            }

            int counter = 1;
            foreach (var platforms in this.PlatformContainer) 
            {
                if (counter == resultNumber)
                {
                    return platforms.FindElements(By.TagName("span"));
                }

                counter++;
            }

            return null;
        }
    
        public string GetSearchBoxValue() => this.SearchBox.GetAttribute("value");
    }
}
