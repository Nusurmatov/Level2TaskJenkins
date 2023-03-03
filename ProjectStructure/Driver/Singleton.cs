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
                        ChromeOptions chromeOptions= new ChromeOptions();
                        chromeOptions.AddArguments("--incognito");
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver(chromeOptions);
                        break;
                    case Browser.Edge:
                        EdgeOptions edgeOptions = new EdgeOptions();
                        edgeOptions.AddArguments("InPrivate");
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver(edgeOptions);
                        break;
                    case Browser.Firefox:
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        firefoxOptions.AddArguments("-private");
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver(firefoxOptions);
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
