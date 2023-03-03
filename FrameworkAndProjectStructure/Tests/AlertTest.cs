using FrameworkAndProjectStructure.Forms;
using FrameworkAndProjectStructure.Utility;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace FrameworkAndProjectStructure.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureEpic("QA Demo Website")]
    public class AlertTest : BaseTest
    {
        [Test]
        public void TestAlerts()
        {
            Assert.IsTrue(this.mainPage.IsOpen(), $"{mainPage.Name} is not open!");
            LoggerUtil.LogToConsole($"{mainPage.Name} is open", isExpectedResult: true);

            var alertsForm = new AlertsForm();
            var testData = TestDataUtil.DeserializeAlertTestData("alertTestData.json");

            base.mainPage.AlertsFramesAndWindowsCard.Click();
            base.alertsFrameAndWindowsForm.AlertsButton.Click();

            Assert.IsTrue(alertsForm.IsOpen(), 
                $"{alertsForm.Name} has not appeared on page!");
            LoggerUtil.LogToConsole($"{alertsForm.Name} has appeared on on page", isExpectedResult: true);

            alertsForm.AlertButton.Click();

            Assert.That(testData.AlertButtonAlertText, Is.EqualTo(AlertUtil.GetText()),
                $"Alert with text '{testData.AlertButtonAlertText}' is not open!");
            LoggerUtil.LogToConsole($"Alert with text '{testData.AlertButtonAlertText}' is open", isExpectedResult: true);

            AlertUtil.Accept();
            alertsForm.ConfirmButton.Click();

            Assert.That(testData.ConfirmBoxAlertText, Is.EqualTo(AlertUtil.GetText()),
                $"Alert with text '{testData.ConfirmBoxAlertText}' is not open!");
            LoggerUtil.LogToConsole($"Alert with text '{testData.ConfirmBoxAlertText}' is open", isExpectedResult: true);

            AlertUtil.Accept();

            Assert.That(testData.ConfirmBoxPageText, Is.EqualTo(alertsForm.ConfirmResultLabel.GetText()),
                $"Text {testData.ConfirmBoxPageText} has not appeared on page!");
            LoggerUtil.LogToConsole($"Text '{testData.ConfirmBoxPageText}' has appeared on page", isExpectedResult: true);

            alertsForm.PromptButton.Click();

            Assert.That(testData.PromptBoxAlertText, Is.EqualTo(AlertUtil.GetText()),
                $"Alert with text '{testData.PromptBoxAlertText}' is not open!");
            LoggerUtil.LogToConsole($"Alert with text '{testData.PromptBoxAlertText}' is open", isExpectedResult: true);

            string randomText = StringUtil.GenerateRandomString(length: 7, IsNumbersAllowed: false);
            AlertUtil.SendKeys(randomText);
            AlertUtil.Accept();

            Assert.IsTrue(alertsForm.PromptResultLabel.GetText().Contains(randomText),
                $"Appeared text does not equal to randomly generated text: '{randomText}'  !!!");
            LoggerUtil.LogToConsole("Appeared text equals to randomly generated text:" +
                $" '{randomText}'", isExpectedResult: true);
        }
    }
}