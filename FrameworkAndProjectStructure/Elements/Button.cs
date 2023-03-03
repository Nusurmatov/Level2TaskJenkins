using FrameworkAndProjectStructure.Utility;
using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Elements
{
    public class Button : BaseElement
    {
        public Button(By uniqueLocator, string name) : base(uniqueLocator, name) { }

        public void Click()
        {
            base.Wait.ForElementPresence(base.UniqueLocator);
            base.Wait.ForElementToBeClickable(base.UniqueLocator);

            this.GetElement().Click();
            LoggerUtil.LogToConsole($"{base.Name} clicked");
        }
    }
}
