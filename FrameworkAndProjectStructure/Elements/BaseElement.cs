using FrameworkAndProjectStructure.Driver;
using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Elements
{
    public abstract class BaseElement
    {
        public readonly By UniqueLocator;

        public readonly string Name;

        protected readonly Wait Wait;

        protected BaseElement(By uniqueLocator, string name) 
        {
            this.UniqueLocator = uniqueLocator;
            this.Name = name;
            this.Wait = new Wait();
        }

        public IWebElement GetElement() => this.Wait.ForElementToExist(this.UniqueLocator);

        public bool IsDisplayed() => this.GetElement().Displayed;
    }
}
