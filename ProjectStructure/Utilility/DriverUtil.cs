using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ProjectStructure.Driver;

namespace ProjectStructure.Utilility
{
    public static class DriverUtil
    {
        public static void ScrollAndOpenLinkInNewTab(IWebElement linkElement)
        {
            Actions action = new Actions(Singleton.Driver());
            action.MoveToElement(linkElement);
            action.Perform();
            linkElement.Click();
        }

        public static void MoveToLastTab() =>
            Singleton.Driver().SwitchTo().Window(Singleton.Driver().WindowHandles.Last());
    }
}
