using NUnit.Framework;
using ProjectStructure.Driver;
using ProjectStructure.Model;
using ProjectStructure.Pages;
using ProjectStructure.Utilility;

namespace ProjectStructure.Tests
{
    public class PrivacyPolicyTest : BaseTest
    {
        [Test]
        public void TestPrivacyPolicyPage()
        {
            var testData = TestDataUtil.DeserializePrivacyPolicyTestData(fileName: "privacyPolicyTestData.json");

            var privacyPolicyPage = new PrivacyPolicyPage();
            base.steamMainPage.ScrollAndOpenPrivacyPolicyInNewTab();
            base.steamMainPage.MoveToPrivacyPolicyTab();

            Assert.That(privacyPolicyPage.PageName.Displayed, Is.True, 
                "Privacy Policy page is not displayed!");  // hard assert

            Assert.IsTrue(privacyPolicyPage.SwitchLanguageElementsList.Displayed, 
                "Switch Language Elements List is not displayed!");  // soft assert

            Assert.IsTrue(privacyPolicyPage.AreAllSupportedLanguagesDisplayed(testData.suppertedLanguages), 
                "Not all supported languages displayed!");  // soft assert

            Assert.IsTrue(privacyPolicyPage.RevisionDate.Text.Contains(DateTime.Now.Year.ToString()), 
                "Policy revision signed is not current year!");  // soft assert
        }
    }
}