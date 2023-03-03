using FrameworkAndProjectStructure.Forms;
using FrameworkAndProjectStructure.Utility;
using NUnit.Framework;

namespace FrameworkAndProjectStructure.Tests
{
    public class TableTest : BaseTest
    {
        [Test]
        public void TestTables()
        {
            Assert.IsTrue(this.mainPage.IsOpen(), $"{mainPage.Name} is not open!");
            LoggerUtil.LogToConsole($"{mainPage.Name} is open", isExpectedResult: true);

            var testData = TestDataUtil.DeserializeTableTestData("tableTestData.json");
            var webTablesForm = new WebTablesForm();
            var registrationForm = new RegistrationForm();

            base.mainPage.ElementsCard.Click();
            base.elementsForm.WebTablesButton.Click();

            Assert.IsTrue(webTablesForm.IsOpen(),
                $"Page with ${webTablesForm.Name} is not open!");
            LoggerUtil.LogToConsole($"Page with {webTablesForm.Name} is open", isExpectedResult: true);

            foreach (var user in testData.User)
            {
                webTablesForm.AddButton.Click();
                Assert.IsTrue(registrationForm.IsOpen(),
                    $"{registrationForm.Name} has not appeared on page!");
                LoggerUtil.LogToConsole($"{registrationForm.Name} has appeared on page", isExpectedResult: true);

                registrationForm.FirstNameInput.SendText(user.FirstName);
                registrationForm.LastNameInput.SendText(user.LastName);
                registrationForm.EmailInput.SendText(user.Email);
                registrationForm.AgeInput.SendText(user.Age.ToString());
                registrationForm.SalaryInput.SendText(user.Salary.ToString());
                registrationForm.DepartmentInput.SendText(user.Department);
                registrationForm.SubmitButton.Click();

                var tableRowElementTexts = user.ToString();
                var index = webTablesForm.GetUserIndex(tableRowElementTexts);

                Assert.That(webTablesForm.GetTableRowElementTextsAt(index), Is.EqualTo(tableRowElementTexts),
                    $"Data of User '{user}' has not appreared in table!");
                LoggerUtil.LogToConsole($"Data of User '{user}' has appreared in table", isExpectedResult: true);

                var deleteButton = webTablesForm.GetDeleteButtonByIndex(index);
                deleteButton.Click();

                Assert.That(webTablesForm.GetTableRowElementTextsAt(index), Is.Not.EqualTo(tableRowElementTexts), 
                    $"Data of User '{user}' has not been deleted from table!");
                LoggerUtil.LogToConsole($"Data of User '{user}' has been deleted from table", isExpectedResult: true);
            }
        }
    }
}