using FrameworkAndProjectStructure.Elements;
using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Forms
{
    public class LinksForm : BaseForm
    {
        private static By UniqueLocator = By.Id("linkWrapper");

        private readonly By HomeLinkLocator = By.Id("simpleLink");

        public Button HomeLink => new Button(HomeLinkLocator, "Home Link");

        public LinksForm() : base(UniqueLocator, "LinksForm") { }
    }
}
