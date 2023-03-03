using ProjectStructure.Driver;
using ProjectStructure.Model;

namespace ProjectStructure.Utilility
{
    public static class UserUtil
    {
        private static string parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        private static User user;

        public static User GetUserConfig() 
        {
            string jsonText = File.ReadAllText(Path.Combine(parentPath, "Data", "configData.json"));
            user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(jsonText);

            return user;
        }

        public static Browser GetBrowser()
        {
            switch (user.browser.ToLowerInvariant())
            {
                default:
                    return Browser.Chrome;
                case "edge":
                    return Browser.Edge;
                case "firefox":
                    return Browser.Firefox;
            }
        }
    }
}
