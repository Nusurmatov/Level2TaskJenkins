using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Elements
{
    public class Frame : BaseElement
    {
        public Frame(By uniqueLocator, string name) : base(uniqueLocator, name) { }
    }
}
