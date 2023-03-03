using NUnit.Framework;
using ProjectStructure.Model;
using ProjectStructure.Pages;
using ProjectStructure.Utilility;

namespace ProjectStructure.Tests
{
    public class GameSearchTest : BaseTest
    {
        [Test]
        public void TestSearchResult()
        {
            var testData = TestDataUtil.DeserializeGameSearchTestData(fileName: "gameSearchTestData.json");

            var searchResultPage = new SearchResultPage();
            base.steamMainPage.Search(testData.searchText);

            Assert.That(searchResultPage.Form.Displayed, Is.True, 
                "Result page is not displayed!");

            Assert.That(searchResultPage.SearchBox.GetAttribute("value"), Is.EqualTo(testData.searchText),
                "Search box on result page does not contain searched name!");

            Assert.That(searchResultPage.Names.First().Text, Is.EqualTo(testData.searchText),
                "The first name is not equal to searched name!");

            SearchResult firstResultInFirstSearch = SearchResultUtil.GetSearchResultPropertiesOf(resultNumber: 1);
            SearchResult secondResultInFirstSearch = SearchResultUtil.GetSearchResultPropertiesOf(resultNumber: 2);

            testData.searchText = secondResultInFirstSearch.Name;
            base.steamMainPage.Search(testData.searchText);

            Assert.That(searchResultPage.SearchBox.GetAttribute("value"), Is.EqualTo(testData.searchText),
                "Search box on result page does not contain searched name");

            SearchResult firstResultInSecondSearch = SearchResultUtil.GetSearchResultPropertiesOf(resultNumber: 1);
            SearchResult secondResultInSecondSearch = SearchResultUtil.GetSearchResultPropertiesOf(resultNumber: 2);

            Assert.IsTrue(firstResultInFirstSearch.Equals(secondResultInSecondSearch),
                "Result list does not contain 2 strored items from previous search or all stored data are not matched!");

            Assert.IsTrue(firstResultInSecondSearch.Equals(secondResultInFirstSearch),
                "Result list does not contain 2 strored items from previous search or all stored data are not matched!");
        }
    }
}
