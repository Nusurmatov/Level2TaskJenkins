using FrameworkAndProjectStructure.Elements;
using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Forms
{
    public class ElementsForm : BaseForm
    {
        private static By UniqueLocator = By.ClassName("//*[@class='main-header']");

        private readonly By WebTablesButtonLocator
            = By.XPath("//*[@class='menu-list']/descendant::span[contains(text(), 'Web') and contains(text(),'Tables')]");

        private readonly By LinksButtonLocator
            = By.XPath("//ul/descendant::span[text()='Links']");

        public Button WebTablesButton => new Button(WebTablesButtonLocator, "Web Tables Button");

        public Button LinksButton => new Button(LinksButtonLocator, "Links Button");

        public ElementsForm() : base(UniqueLocator, "Elements Form") { }
    }
}
