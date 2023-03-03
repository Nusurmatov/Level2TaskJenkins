using FrameworkAndProjectStructure.Driver;
using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Forms
{
    public abstract class BaseForm
    {
        private readonly By UniqueLocator;

        public string Name { get; private set; }

        protected readonly Wait Wait;

        protected BaseForm(By uniqueLocator, string name)
        {
            this.Name = name;
            this.UniqueLocator = uniqueLocator;
            this.Wait = new Wait();
        }

        public bool IsOpen() => this.Wait.ForElementToExist(this.UniqueLocator).Displayed;
    }
}
