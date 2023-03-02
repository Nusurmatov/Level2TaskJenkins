using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Driver
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
                    case Browser.Chrome:
                        driver = Factory.ChromeInit();
                        break;
                    case Browser.Firefox:
                        driver = Factory.FirefoxInit(); 
                        break;
                    case Browser.Edge: 
                        driver = Factory.EdgeInit(); 
                        break;
                    default:
                        throw new ArgumentException("Invalid Browser type!");
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
