using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace FrameworkAndProjectStructure.Driver
{
    public static class Factory
    {
        public static IWebDriver ChromeInit()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            
            return new ChromeDriver();
        }

        public static IWebDriver FirefoxInit()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());

            return new FirefoxDriver();
        }

        public static IWebDriver EdgeInit()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());

            return new EdgeDriver();
        }
    }
}
