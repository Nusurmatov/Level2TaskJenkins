using FrameworkAndProjectStructure.Elements;
using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Forms
{
    public class AlertsFrameAndWindowsForm : BaseForm
    {
        private static By UniqueLocator = By.ClassName("//*[@class='main-header']");
        
        private readonly By BrowserWindowsButtonLocator
            = By.XPath("//*[@class='menu-list']/descendant::span" +
                "[contains(text(), 'Browser') and contains(text(), 'Windows')]");

        private readonly By AlertsButtonLocator
            = By.XPath("//*[@class='menu-list']/descendant::span[contains(text(), 'Alerts')]");

        private readonly By FramesButtonLocator
            = By.XPath("//*[@class='menu-list']/descendant::span[contains(text(), 'Frames')]");

        private readonly By NestedFramesButtonLocator
            = By.XPath("//*[@class='menu-list']/descendant::span[contains(text(), 'Nested') and contains(text(), 'Frames')]");

        public Button BrowserWindowsButton
            => new Button(BrowserWindowsButtonLocator, "Browser Windows Button");

        public Button AlertsButton => new Button(AlertsButtonLocator, "Alerts Button");

        public Button FramesButton => new Button(FramesButtonLocator, "Nested Frames Button");

        public Button NestedFramesButton => new Button(NestedFramesButtonLocator, "Nested Frames Button");

        public AlertsFrameAndWindowsForm() : base(UniqueLocator, "Alerts, Frame & Windows Form") { }
    }
}
