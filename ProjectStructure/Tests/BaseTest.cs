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
            Console.WriteLine($"User Name: {user.Name}");
            Console.WriteLine($"Running on {user.Browser}");

            steamMainPage = new SteamMainPage();
            Singleton.Driver().Navigate().GoToUrl(user.Url);
            Singleton.Driver().Manage().Window.Maximize();
        }

        [TearDown]
        public void Teardown() => Singleton.CloseBrowser();
    }
}
