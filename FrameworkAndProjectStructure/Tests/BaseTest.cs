using FrameworkAndProjectStructure.Driver;
using FrameworkAndProjectStructure.Forms;
using FrameworkAndProjectStructure.Utility;
using NUnit.Framework;

namespace FrameworkAndProjectStructure.Tests
{
    public class BaseTest
    {
        protected MainPage mainPage;
        protected AlertsFrameAndWindowsForm alertsFrameAndWindowsForm;
        protected ElementsForm elementsForm;

        [SetUp]
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
        public void TearDown()
        {
            Singleton.CloseBrowser();
            TimeUtil.StopWatch();
            LoggerUtil.Info(TestContext.CurrentContext.Result.Outcome.Status);
        }
    }
}