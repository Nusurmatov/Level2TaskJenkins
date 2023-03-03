using FrameworkAndProjectStructure.Elements;
using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Forms
{
    public class FramesForm : BaseForm
    {
        private static By UniqueLocator = By.Id("framesWrapper");

        private readonly By UpperFrameLocator = By.Id("frame1");

        private readonly By UpperFrameLabelLocator = By.Id("sampleHeading");

        private readonly By LowerFrameLocator = By.Id("frame2");

        private readonly By LowerFrameLabelLocator = By.Id("sampleHeading");

        public Frame UpperFrame => new Frame(UpperFrameLocator, "Upper Frame");

        public Frame LowerFrame => new Frame(LowerFrameLocator, "Lower Frame");

        public Label UpperFrameLabel => new Label(UpperFrameLabelLocator, "Upper Frame Label");

        public Label LowerFrameLabel => new Label(LowerFrameLabelLocator, "Lower Frame Label");

        public FramesForm() : base(UniqueLocator, "Frames Form") { }
    }
}
