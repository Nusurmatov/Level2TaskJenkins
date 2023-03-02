using FrameworkAndProjectStructure.Utility;
using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Elements
{
    public class Tables : BaseElement
    {
        public Tables(By uniqueLocator, string name) : base(uniqueLocator, name) { }

        public IReadOnlyCollection<IWebElement> GetElements()
        {
            base.Wait.ForElementToExist(base.UniqueLocator);

            return DriverUtil.GetElements(base.UniqueLocator);
        }
    }
}
