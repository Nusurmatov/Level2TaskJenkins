using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace ProjectStructure.Driver
{
    public static class BrowserFactory
    {
        public static IWebDriver InitChrome()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--incognito");
            new DriverManager().SetUpDriver(new ChromeConfig());
            
            return new ChromeDriver(chromeOptions);
        }

        public static IWebDriver InitEdge() 
        {
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.AddArguments("InPrivate");
            new DriverManager().SetUpDriver(new EdgeConfig());
            
            return new EdgeDriver(edgeOptions);
        }

        public static IWebDriver InitFirefox() 
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArguments("-private");
            new DriverManager().SetUpDriver(new FirefoxConfig());

            return new FirefoxDriver(firefoxOptions);
        }


    }
}
