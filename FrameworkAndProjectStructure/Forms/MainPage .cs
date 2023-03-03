using FrameworkAndProjectStructure.Elements;
using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Forms
{
    public class MainPage : BaseForm
    {
        private static By UniqueLocator = By.ClassName("home-banner");

        private readonly By AlertsFrameAndWindowsCardLocator 
            = By.XPath("//*[@class='category-cards']/descendant::h5" +
                "[contains(text(), 'Alerts') and contains(text(), 'Frame') " +
                "and contains(text(), 'Windows')]/ancestor::div[contains(@class, 'top-card')]");

        private readonly By ElementsCardLocator
            = By.XPath("//*[@class='category-cards']/descendant::h5[contains(text(), 'Elements')]" +
                "/ancestor::div[contains(@class, 'top-card')]");

        public Button AlertsFramesAndWindowsCard 
            => new Button(AlertsFrameAndWindowsCardLocator, "Alerts, Frames & Windows Card");

        public Button ElementsCard => new Button(ElementsCardLocator, "Elements Card");

        public MainPage() : base(UniqueLocator, "ToolsQA Main Page") { }
    }
}
