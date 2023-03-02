using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Utility
{
    public static class AlertUtil
    {
        private static IAlert alert = DriverUtil.SwitchToAlert();

        public static string GetText() => alert.Text;

        public static void Accept()
        { 
            alert.Accept();
            LoggerUtil.LogToConsole("OK button clicked");
        }

        public static void Dismiss()
        {
            alert.Dismiss();
            LoggerUtil.LogToConsole("Cancel button clicked");
        }

        public static void SendKeys(string text)
        {
            alert.SendKeys(text);
            LoggerUtil.LogToConsole($"'{text}' entered in Alert input box");
        }
    }
}
