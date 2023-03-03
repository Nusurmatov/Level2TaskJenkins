using Allure.Commons;
using FrameworkAndProjectStructure.Driver;
using FrameworkAndProjectStructure.Forms;
using FrameworkAndProjectStructure.Utility;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace FrameworkAndProjectStructure.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureEpic("QA Demo Website")]
    public class BaseTest
    {
        protected MainPage mainPage;
        protected AlertsFrameAndWindowsForm alertsFrameAndWindowsForm;
        protected ElementsForm elementsForm;

        [SetUp]
        [AllureStep("Opening Demo Website and Maximizing it")]
        public void Setup()
        {
            TimeUtil.StartWatch();
            var model = ConfigUtil.GetUserConfig();
            Singleton.Driver(ConfigUtil.GetBrowser()).Navigate().GoToUrl(model.Url);
            Singleton.Driver().Manage().Window.Maximize();
            LoggerUtil.Info(model);

            mainPage = new MainPage();
            alertsFrameAndWindowsForm= new AlertsFrameAndWindowsForm();
            elementsForm= new ElementsForm();
        }

        [TearDown]
        [AllureStep("Finishing and Taking Screentshots of Failed Tests")]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                byte[] currentScreenshot = ScreenshotUtil.TakeAndSaveScreenshot(Singleton.Driver());
                AllureLifecycle.Instance.AddAttachment("Failed Screentshot", "image/jpeg", currentScreenshot);
            }

            Singleton.CloseBrowser();
            TimeUtil.StopWatch();
            LoggerUtil.Info(TestContext.CurrentContext.Result.Outcome.Status);
        }
    }
}