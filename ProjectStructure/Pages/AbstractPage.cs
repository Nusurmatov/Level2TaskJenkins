using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectStructure.Driver;
using SeleniumExtras.WaitHelpers;

namespace ProjectStructure.Pages
{
    public abstract class AbstractPage
    {
        private const int WaitTimeOut = 15;

        public readonly IWebDriver Driver;

        public readonly WebDriverWait Wait;
        
        protected AbstractPage(Browser browser = Browser.Chrome)
        {
            this.Driver = Singleton.Driver(browser);
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(WaitTimeOut));
        }

        public IWebElement WaitAndFindElement(By locator) => this.Wait.Until(ExpectedConditions.ElementExists(locator));
    }
}
