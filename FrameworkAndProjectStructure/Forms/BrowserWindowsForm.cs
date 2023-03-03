using FrameworkAndProjectStructure.Elements;
using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Forms
{
    public class BrowserWindowsForm : BaseForm
    {
        private static By UniqueLocator = By.Id("browserWindows");

        private readonly By ElementsButtonLocator 
            = By.XPath("//*[@class='accordion']/descendant::div" +
                "[@class='header-text' and contains(text(),'Elements')]");

        private readonly By NewTabButtonLocator = By.Id("tabButton");

        public Button ElementsButton => new Button(ElementsButtonLocator, "Elements Button");

        public Button NewTabButton => new Button(NewTabButtonLocator, "New Tab Button");

        public BrowserWindowsForm() : base(UniqueLocator, "Browser Windows Form") { }
    }
}
