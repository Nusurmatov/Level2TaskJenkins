using OpenQA.Selenium;
using FrameworkAndProjectStructure.Elements;

namespace FrameworkAndProjectStructure.Forms
{
    public class NestedFramesForm : BaseForm
    {
        private static By UniqueLocator = By.Id("framesWrapper");

        private readonly By ParentFrameLocator = By.XPath("//*[@id='framesWrapper']/descendant::iframe");

        private readonly By ParentFrameLabelLocator = By.XPath("//body[contains(text(), 'Parent')]");

        private readonly By ChildFrameLocator = By.XPath("//body[contains(text(),'Parent')]/child::iframe");

        private readonly By ChildFrameLabelLocator = By.XPath("//p[contains(text(), 'Child')]");

        public Frame ParentFrame => new Frame(ParentFrameLocator, "Parent Frame");

        public Frame ChildFrame => new Frame(ChildFrameLocator, "Child Frame");

        public Label ParentFrameLabel => new Label(ParentFrameLabelLocator, "Parent Frame Label");

        public Label ChildFrameLabel => new Label(ChildFrameLabelLocator, "Child Frame Label");

        public NestedFramesForm() : base(UniqueLocator, "Nested Frames Form") { }
    }
}
