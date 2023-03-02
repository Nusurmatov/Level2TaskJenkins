using NUnit.Framework;
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
            DriverUtil.ScrollAndOpenLinkInNewTab(steamMainPage.PrivactPolicy);
            DriverUtil.MoveToLastTab();

            Assert.That(privacyPolicyPage.PageName.Displayed, Is.True, 
                "Privacy Policy page is not displayed!");  

            Assert.Multiple(() =>
            {
                Assert.IsTrue(privacyPolicyPage.SwitchLanguageElementsList.Displayed,
                    "Switch Language Elements List is not displayed!");  

                Assert.IsTrue(privacyPolicyPage.AreAllSupportedLanguagesDisplayed(testData.SuppertedLanguages),
                    "Not all supported languages displayed!"); 

                Assert.IsTrue(privacyPolicyPage.RevisionDate.Text.Contains(DateTime.Now.Year.ToString()),
                    "Policy revision signed is not current year!");  
            });
        }
    }
}