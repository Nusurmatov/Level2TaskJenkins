using FrameworkAndProjectStructure.Models;
using NUnit.Framework.Interfaces;
using System.Text;

namespace FrameworkAndProjectStructure.Utility
{
    public static class LoggerUtil
    {
        private static string parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        
        private static StringBuilder stringBuilder = new StringBuilder();

        public static void Info(ConfigModel model)
        {
            LogToConsole($"User: {model.Name}, Browser: {model.Browser}");
            LogToConsole("----------------------------------------------------\n");
        }

        public static void Info(TestStatus status)
        {
            LogToConsole("\n----------------------------------------------------");
            LogToConsole($"Execution Time: {TimeUtil.GetElapsedTime()} ms, Status: {status}");
            LogToFile(stringBuilder.ToString(), status);  
            stringBuilder.Clear();
        }

        public static void LogToConsole(string message, bool isExpectedResult = false)
        {
            if (isExpectedResult) 
            {
                stringBuilder.Append($"   --->   {message}\n");
                Console.Write($"   -->   {message}\n");
            }
            else
            {
                stringBuilder.AppendLine(message);
                Console.WriteLine(message);
            }
        }

        private static void LogToFile(string messeage, TestStatus status)
        {
            var fileName = Path.Combine(parentPath, "Data", "Log", 
                $"log_{status}_{TimeUtil.GetTimeStamp(DateTime.Now)}.txt");
        
            using(var writer = new StreamWriter(fileName)) 
            {
                writer.Write(messeage);
            }
        }
    }
}
