using FrameworkAndProjectStructure.Models;

namespace FrameworkAndProjectStructure.Utility
{
    public static class TestDataUtil
    {
        private static string parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        private static string jsonText;

        public static UserModel DeserializeTableTestData(string fileName)
        {
            jsonText = File.ReadAllText(Path.Combine(parentPath, "Data", fileName));

            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(jsonText);
        }

        public static AlertTestDataModel DeserializeAlertTestData(string fileName) 
        {
            jsonText = File.ReadAllText(Path.Combine(parentPath, "Data", fileName));

            return Newtonsoft.Json.JsonConvert.DeserializeObject<AlertTestDataModel>(jsonText);
        }

        public static FrameTestDataModel DeserializeFrameTestData(string filename)
        {
            jsonText = File.ReadAllText(Path.Combine(parentPath, "Data", filename));

            return Newtonsoft.Json.JsonConvert.DeserializeObject<FrameTestDataModel>(jsonText);
        }
    }
}
