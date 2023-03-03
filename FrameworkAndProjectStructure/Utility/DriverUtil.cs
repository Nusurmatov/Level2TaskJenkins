using FrameworkAndProjectStructure.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace FrameworkAndProjectStructure.Utility
{
    public static class DriverUtil
    {
        private static IWebDriver driver = Singleton.Driver();

        private static IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;

        public static int GetElementsCount(By locator) => driver.FindElements(locator).Count();

        public static IReadOnlyCollection<IWebElement> GetElements(By locator) => driver.FindElements(locator);

        public static IReadOnlyCollection<IWebElement> GetElements(this IWebElement element, By locator)
            => element.FindElements(locator);

        public static void SwitchToLastTab() => driver.SwitchTo().Window(driver.WindowHandles.Last());

        public static void CloseCurrentTab() => driver.Close();

        public static void SwitchToFirstTab() => driver.SwitchTo().Window(driver.WindowHandles.First());

        public static void MoveToElement(IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element);
            action.Perform();
        }

        public static IAlert SwitchToAlert() => driver.SwitchTo().Alert();

        public static void SwitchToFrame(IWebElement element) => driver.SwitchTo().Frame(element);

        public static void SwitchToDefaultContent() => driver.SwitchTo().DefaultContent();

        public static void ScrollToPageBottom() 
            => jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
    }
}
