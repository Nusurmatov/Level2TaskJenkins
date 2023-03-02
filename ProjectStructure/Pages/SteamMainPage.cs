using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ProjectStructure.Driver;

namespace ProjectStructure.Pages
{
    public class SteamMainPage : BasePage
    {
        private readonly By SearchBoxLocator = By.Id("store_nav_search_term");

        private readonly By PrivacyPolicyLocator = 
            By.XPath("//div[@id='footer_text']/descendant::a[contains(text(), 'Privacy')]");

        public IWebElement SearchBox => base.WaitAndFindElement(SearchBoxLocator);

        public IWebElement PrivactPolicy => base.WaitAndFindElement(PrivacyPolicyLocator);

        public SteamMainPage() : base() { }

        public void Search(string text) => this.SearchBox.SendKeys(text + Keys.Enter);
    }
}
