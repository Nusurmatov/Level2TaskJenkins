using ProjectStructure.Model;

namespace ProjectStructure.Utilility
{
    public static class TestDataUtil
    {
        private static string parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public static GameSearchTestData DeserializeGameSearchTestData(string fileName)
        {
            string jsonText = File.ReadAllText(Path.Combine(parentPath, "Data", fileName));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GameSearchTestData>(jsonText);
        }

        public static PrivacyPolicyTestData DeserializePrivacyPolicyTestData(string fileName)
        {
            string jsonText = File.ReadAllText(Path.Combine(parentPath, "Data", fileName));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PrivacyPolicyTestData>(jsonText);
        }
    }
}
