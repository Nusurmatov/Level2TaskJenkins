using FrameworkAndProjectStructure.Utility;
using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Elements
{
    public class Input : BaseElement
    {
        public Input(By uniqueLocator, string name) : base(uniqueLocator, name) { }

        public void SendText(string text)
        {
            base.GetElement().SendKeys(text);
            LoggerUtil.LogToConsole($"'{text}' entered to {base.Name}");
        }    
    }
}
