using FrameworkAndProjectStructure.Utility;
using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Elements
{
    public class Button : BaseElement
    {
        public Button(By uniqueLocator, string name) : base(uniqueLocator, name) { }
    }
}
