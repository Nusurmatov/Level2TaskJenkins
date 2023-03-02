using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectStructure.Driver;
using SeleniumExtras.WaitHelpers;

namespace ProjectStructure.Pages
{
    public abstract class BasePage
    {
        public readonly WebDriverWait Wait;
        
        protected BasePage(int waitTimeOut = 15)
           => this.Wait = new WebDriverWait(Singleton.Driver(), TimeSpan.FromSeconds(waitTimeOut));

        public IWebElement WaitAndFindElement(By locator) 
            => this.Wait.Until(ExpectedConditions.ElementExists(locator));
    }
}
