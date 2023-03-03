using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Utility
{
    public static class ScreenshotUtil
    {
        private static string _parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public static byte[] TakeAndSaveScreenshot(IWebDriver driver)
        {
            ITakesScreenshot? ts = driver as ITakesScreenshot;
            Screenshot screenshot = ts.GetScreenshot();
            SaveScreenShotWithTimeStamp(screenshot);
                
            return screenshot.AsByteArray;
        }

        private static void SaveScreenShotWithTimeStamp(Screenshot screenshot)
        {
            DateTime dateTime = DateTime.Now;
            screenshot.SaveAsFile(Path.Combine(_parentPath, "Screenshots", 
                $"screenshot_{TimeUtil.GetTimeStamp(dateTime)}.jpeg"));
        }
    }
}
