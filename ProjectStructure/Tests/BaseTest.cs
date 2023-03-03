using NUnit.Framework;
using ProjectStructure.Driver;
using ProjectStructure.Pages;
using ProjectStructure.Utilility;

namespace ProjectStructure.Tests
{
    public class BaseTest
    {
        protected SteamMainPage steamMainPage;

        [SetUp]
        public void Setup()
        {
            var user = UserUtil.GetUserConfig();
            Console.WriteLine($"User Name: {user.name}");
            Console.WriteLine($"Running on {user.browser}");

            steamMainPage = new SteamMainPage(UserUtil.GetBrowser());
            steamMainPage.GoTo();
            steamMainPage.Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Teardown() => Singleton.CloseBrowser();
    }
}
