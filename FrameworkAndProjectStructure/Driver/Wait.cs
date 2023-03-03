using FrameworkAndProjectStructure.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FrameworkAndProjectStructure.Driver
{
    public class Wait
    {
        private static int waitTimeOut = ConfigUtil.GetWaitTimeOut();

        private WebDriverWait wait =>
            new WebDriverWait(Singleton.Driver(), TimeSpan.FromSeconds(waitTimeOut));

        public IWebElement ForElementToExist(By locator)
            => wait.Until(ExpectedConditions.ElementExists(locator));

        public void ForElementPresence(By locator)
            => wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));

        public void ForElementToBeClickable(By locator)
            => wait.Until(ExpectedConditions.ElementToBeClickable(locator));
    }
}
