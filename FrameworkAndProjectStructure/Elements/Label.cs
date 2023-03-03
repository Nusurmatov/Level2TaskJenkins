using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Elements
{
    public class Label : BaseElement
    {
        public Label(By uniqueLocator, string name) : base(uniqueLocator, name) { }

        public string GetText() => base.GetElement().Text;
    }
}
