using FrameworkAndProjectStructure.Forms;
using FrameworkAndProjectStructure.Utility;
using NUnit.Framework;

namespace FrameworkAndProjectStructure.Tests
{
    public class HandleTest : BaseTest
    {
        [Test]
        public void TestHandles()
        {
            Assert.IsTrue(this.mainPage.IsOpen(), $"{mainPage.Name} is not open!");
            LoggerUtil.LogToConsole($"{mainPage.Name} is open", isExpectedResult: true);

            var browsesWindowsForm = new BrowserWindowsForm();

            base.mainPage.AlertsFramesAndWindowsCard.Click();
            base.alertsFrameAndWindowsForm.BrowserWindowsButton.Click();

            Assert.IsTrue(browsesWindowsForm.IsOpen(),
                $"Page with {browsesWindowsForm.Name} is not open!");
            LoggerUtil.LogToConsole($"Page with {browsesWindowsForm.Name} is open", isExpectedResult: true);

            browsesWindowsForm.NewTabButton.Click();
            DriverUtil.SwitchToLastTab();
            var samplePage = new SamplePage();

            Assert.IsTrue(samplePage.IsOpen(), $"New Tab with {samplePage.Name} is not open!");
            LoggerUtil.LogToConsole($"New Tab with {samplePage.Name} is open", isExpectedResult: true);

            DriverUtil.CloseCurrentTab();
            DriverUtil.SwitchToFirstTab();

            Assert.IsTrue(browsesWindowsForm.IsOpen(),
                $"Page with {browsesWindowsForm.Name} is not open!");
            LoggerUtil.LogToConsole($"Page with {browsesWindowsForm.Name} is open", isExpectedResult: true);

            browsesWindowsForm.ElementsButton.Click();
            DriverUtil.ScrollToPageBottom();
            base.elementsForm.LinksButton.Click();
            var linksForm = new LinksForm();

            Assert.IsTrue(linksForm.IsOpen(), $"Page with {linksForm.Name} is not open!");
            LoggerUtil.LogToConsole($"Page with {linksForm.Name} is open", isExpectedResult: true);

            linksForm.HomeLink.Click();
            DriverUtil.SwitchToLastTab();

            Assert.IsTrue(mainPage.IsOpen(), $"New Tab with {mainPage.Name} is not open!");
            LoggerUtil.LogToConsole($"New Tab with {mainPage.Name} is open", isExpectedResult: true);

            DriverUtil.SwitchToFirstTab();

            Assert.IsTrue(linksForm.IsOpen(), $"Page with {linksForm.Name} is not open!");
            LoggerUtil.LogToConsole($"Page with {linksForm.Name} is open", isExpectedResult: true);
        }
    }
}