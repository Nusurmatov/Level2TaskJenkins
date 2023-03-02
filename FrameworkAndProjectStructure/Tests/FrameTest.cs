using FrameworkAndProjectStructure.Forms;
using FrameworkAndProjectStructure.Utility;
using NUnit.Framework;

namespace FrameworkAndProjectStructure.Tests
{
    public class FrameTest : BaseTest
    {
        [Test]
        public void TestIFrames()
        {
            Assert.IsTrue(this.mainPage.IsOpen(), $"{mainPage.Name} is not open!");
            LoggerUtil.LogToConsole($"{mainPage.Name} is open", isExpectedResult: true);

            var testData = TestDataUtil.DeserializeFrameTestData("frameTestData.json");
            var nestedFramesForm = new NestedFramesForm();

            base.mainPage.AlertsFramesAndWindowsCard.Click();
            DriverUtil.ScrollToPageBottom();
            base.alertsFrameAndWindowsForm.NestedFramesButton.Click();

            Assert.IsTrue(nestedFramesForm.IsOpen(),
                $"Page with '{nestedFramesForm.Name}' is not open!");
            LoggerUtil.LogToConsole($"Page with '{nestedFramesForm.Name}' is open", isExpectedResult: true);

            DriverUtil.SwitchToFrame(nestedFramesForm.ParentFrame.GetElement());

            Assert.Multiple(() =>
            {
                Assert.That(nestedFramesForm.ParentFrameLabel.GetText(), Is.EqualTo(testData.ParentFrameLabelText),
                    $"Message '{testData.ParentFrameLabelText}' is not present on page!");
                LoggerUtil.LogToConsole($"Message '{testData.ParentFrameLabelText}' is present on page",
                    isExpectedResult: true);

                DriverUtil.SwitchToFrame(nestedFramesForm.ChildFrame.GetElement());

                Assert.That(nestedFramesForm.ChildFrameLabel.GetText(), Is.EqualTo(testData.ChildFrameLabelText),
                    $"Message '{testData.ChildFrameLabelText}' is not present on page!");
                LoggerUtil.LogToConsole($"Message '{testData.ChildFrameLabelText}' is present on page",
                    isExpectedResult: true);
            });

            DriverUtil.SwitchToDefaultContent();
            DriverUtil.ScrollToPageBottom();
            base.alertsFrameAndWindowsForm.FramesButton.Click();
            DriverUtil.ScrollToPageBottom();
            var framesForm = new FramesForm();

            Assert.IsTrue(framesForm.IsOpen(),
                $"Page with '{framesForm.Name}' is not open!");
            LoggerUtil.LogToConsole($"Page with '{framesForm.Name}' is open", isExpectedResult: true);

            DriverUtil.SwitchToFrame(framesForm.UpperFrame.GetElement());
            var upperFrameText = framesForm.UpperFrameLabel.GetText();

            DriverUtil.SwitchToDefaultContent();
            DriverUtil.SwitchToFrame(framesForm.LowerFrame.GetElement());
            var lowerFrameText = framesForm.LowerFrameLabel.GetText();

            Assert.That(lowerFrameText, Is.EqualTo(upperFrameText),
                $"Message from upper frame '{upperFrameText}' is not equal to " +
                $"message from lower frame '{lowerFrameText}' !!!");
            LoggerUtil.LogToConsole($"Message from upper frame '{upperFrameText}' is equal to\n" +
                                    $"\t\t message from lower frame '{lowerFrameText}'", isExpectedResult: true);
        }
    }
}