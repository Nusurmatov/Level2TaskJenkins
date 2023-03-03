using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ProjectStructure.Driver;

namespace ProjectStructure.Pages
{
    public class SteamMainPage : AbstractPage
    {
        private string Url => "https://store.steampowered.com/";

        private readonly By SearchBoxLocator = By.Id("store_nav_search_term");

        private readonly By PrivacyPolicyLocator = 
            By.XPath("//div[@id='footer_text']/descendant::a[contains(text(), 'Privacy')]");

        public IWebElement SearchBox => base.WaitAndFindElement(SearchBoxLocator);

        public IWebElement PrivactPolicy => base.WaitAndFindElement(PrivacyPolicyLocator);

        public SteamMainPage(Browser browser = Browser.Chrome) : base(browser) { }

        public void GoTo() => base.Driver.Navigate().GoToUrl(this.Url);

        public void Search(string text) => this.SearchBox.SendKeys(text + Keys.Enter);

        public void ScrollAndOpenPrivacyPolicyInNewTab()
        {
            Actions action = new Actions(base.Driver);
            action.MoveToElement(PrivactPolicy);
            action.Perform();
            PrivactPolicy.Click();
        }
    
        public void MoveToPrivacyPolicyTab() =>
            base.Driver.SwitchTo().Window(base.Driver.WindowHandles.Last());
    }
}
