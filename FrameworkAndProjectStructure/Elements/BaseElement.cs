using FrameworkAndProjectStructure.Driver;
using FrameworkAndProjectStructure.Utility;
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

        public void Click()
        {
            this.Wait.ForElementPresence(this.UniqueLocator);
            this.Wait.ForElementToBeClickable(this.UniqueLocator);

            this.GetElement().Click();
            LoggerUtil.LogToConsole($"{this.Name} clicked");
        }

        public string GetText() => this.GetElement().Text;

        public bool IsDisplayed() => this.GetElement().Displayed;
    }
}
