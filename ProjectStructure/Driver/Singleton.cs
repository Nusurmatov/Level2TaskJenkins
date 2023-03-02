using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ProjectStructure.Driver
{

    public class Singleton
    {
        private static IWebDriver? driver;

        private Singleton() { }

        public static IWebDriver Driver(Browser browser = Browser.Chrome)
        {
            if (driver == null)
            {
                switch (browser)
                {
                    default:
                        driver = BrowserFactory.InitChrome();
                        break;
                    case Browser.Edge:
                        driver = BrowserFactory.InitEdge();
                        break;
                    case Browser.Firefox:
                        driver = BrowserFactory.InitFirefox();
                        break;
                }
            }

            return driver;
        }

        public static void CloseBrowser()
        {
            driver?.Quit();
            driver = null;
        }
    }
}
