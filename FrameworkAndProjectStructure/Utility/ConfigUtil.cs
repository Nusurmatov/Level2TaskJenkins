using FrameworkAndProjectStructure.Driver;
using FrameworkAndProjectStructure.Models;

namespace FrameworkAndProjectStructure.Utility
{
    public static class ConfigUtil
    {
        private static string parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        private static ConfigModel model;

        public static ConfigModel GetUserConfig()
        {
            string jsonText = File.ReadAllText(Path.Combine(parentPath, "Data", "configData.json"));
            model = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigModel>(jsonText);

            return model;
        }

        public static Driver.Browser GetBrowser()
        {
            switch (model.Browser.ToLowerInvariant().Trim())
            {
                default:
                    return Driver.Browser.Chrome;
                case "edge":
                    return Driver.Browser.Edge;
                case "firefox":
                    return Driver.Browser.Firefox;
            }
        }

        public static int GetWaitTimeOut() => model.WaitTimeOut;
    }
}
