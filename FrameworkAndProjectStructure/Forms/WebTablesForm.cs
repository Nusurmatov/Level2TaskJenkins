using FrameworkAndProjectStructure.Elements;
using FrameworkAndProjectStructure.Utility;
using OpenQA.Selenium;
using System.Text;

namespace FrameworkAndProjectStructure.Forms
{
    public class WebTablesForm : BaseForm
    {
        private static By UniqueLocator 
            = By.XPath("//*[contains(@class, 'ReactTable')]/child::div[contains(@class, 'table')]");

        private readonly By AddButtonLocator = By.Id("addNewRecordButton");

        private readonly By TableRowsLocator = By.XPath("//div[not(contains(@class, 'header'))]/div[@role='row']");

        private readonly By TableRowElementsLocator = By.XPath(".//*[@role='gridcell']");

        public Button AddButton => new Button(AddButtonLocator, "Add Button");

        public WebTablesForm() : base(UniqueLocator, "Web Tables Form") { }

        public Tables TableRows => new Tables(TableRowsLocator, "Table Rows");

        public Tables WebTables => new Tables(UniqueLocator, "Web Tables");

        public IReadOnlyCollection<IWebElement> GetTableRowElementsAt(int index)
        {
            int counter = 0;

            foreach (var element in TableRows.GetElements())
            {
                if (counter == index)
                {
                    return DriverUtil.GetElements(element, this.TableRowElementsLocator);
                }

                counter++;
            }

            return null;
        }

        public string GetTableRowElementTextsAt(int index) 
        {
            var stringBuilder = new StringBuilder();
            var elements = this.GetTableRowElementsAt(index);

            foreach (var element in elements)
            {
                stringBuilder.Append(element.Text);
            }

            return stringBuilder.ToString().Trim();
        }

        public int GetUserIndex(string tableRowElementTexts)
        {
            for (int i = 0; i < DriverUtil.GetElementsCount(this.TableRowsLocator); i++)
            {
                if (this.GetTableRowElementTextsAt(i) == tableRowElementTexts)
                {
                    return i;
                }
            }

            throw new ArgumentException($"There are no user as {tableRowElementTexts}!");
        }

        public Button GetDeleteButtonByIndex(int index)
            => new Button(By.XPath($"//*[@title='Delete' and contains(@id, '{index+1}')]"), "Delete Button");
        }
}
