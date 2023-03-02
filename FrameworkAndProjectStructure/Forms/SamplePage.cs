using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Forms
{
    public class SamplePage : BaseForm
    {
        private static By UniqueLocator = By.Id("sampleHeading");

        public SamplePage() : base(UniqueLocator, "Sample Page") { }
    }
}
