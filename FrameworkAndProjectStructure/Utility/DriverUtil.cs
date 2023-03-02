using FrameworkAndProjectStructure.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace FrameworkAndProjectStructure.Utility
{
    public class DriverUtil
    {
        public static int GetElementsCount(By locator) => Singleton.Driver().FindElements(locator).Count();

        public static IReadOnlyCollection<IWebElement> GetElements(By locator) 
            => Singleton.Driver().FindElements(locator);

        public static IReadOnlyCollection<IWebElement> GetElements(IWebElement element, By locator)
            => element.FindElements(locator);

        public static void SwitchToLastTab() 
            => Singleton.Driver().SwitchTo().Window(Singleton.Driver().WindowHandles.Last());

        public static void CloseCurrentTab() => Singleton.Driver().Close();

        public static void SwitchToFirstTab() 
            => Singleton.Driver().SwitchTo().Window(Singleton.Driver().WindowHandles.First());

        public static void MoveToElement(IWebElement element)
        {
            Actions action = new Actions(Singleton.Driver());
            action.MoveToElement(element);
            action.Perform();
        }

        public static IAlert SwitchToAlert() => Singleton.Driver().SwitchTo().Alert();

        public static void SwitchToFrame(IWebElement element) 
            => Singleton.Driver().SwitchTo().Frame(element);

        public static void SwitchToDefaultContent() 
            => Singleton.Driver().SwitchTo().DefaultContent();

        public static void ScrollToPageBottom()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Singleton.Driver();
            jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }
    }
}
