using ProjectStructure.Model;
using ProjectStructure.Pages;

namespace ProjectStructure.Utilility
{
    public static class SearchResultUtil
    {
        private static SearchResultPage searchResultPage = new SearchResultPage();

        public static SearchResult GetSearchResultPropertiesOf(int resultNumber)
        {
            var searchResult = new SearchResult()
            {
                Name = GetNameOf(resultNumber),
                Platforms = GetPlatformsOf(resultNumber),
                RealeseDate = GetReleaseDateOf(resultNumber),
                ReviewSummary= GetReviewSummaryOf(resultNumber),
                Price= GetPriceOf(resultNumber)
            };

            return searchResult;
        }
      
        public static void PrintToConsole(this SearchResult result)
        {
            Console.WriteLine($"Name - {result.Name}");
            Console.WriteLine("Platforms:");
            foreach (var platform in result.Platforms) 
            {
                Console.WriteLine($"\t- {platform}");
            }
            Console.WriteLine($"Release Date: {result.RealeseDate}");
            Console.WriteLine($"Review Summary: {result.ReviewSummary}");
            Console.WriteLine($"Price: {result.Price:c2}\n");
        }

        private static string GetNameOf(int resultNumber)
        {
            if (resultNumber < 1 && resultNumber > searchResultPage.Names.Count)
            {
                throw new ArgumentException($"Invalid search result number: {resultNumber}!");
            }

            string result = string.Empty;
            int counter = 1;
            foreach (var name in searchResultPage.Names ) 
            {
                if (counter == resultNumber)
                {
                    result = name.Text; 
                }

                counter++;
            }

            return result;
        }

        private static List<string> GetPlatformsOf(int resultNumber)
        {
            var elements = searchResultPage.GetPlatformElementsOf(resultNumber);

            var platforms = new List<string>();
            foreach (var element in elements) 
            {
                platforms.Add(element.GetAttribute("class"));
            }

            return platforms;
        }

        private static string GetReleaseDateOf(int resultNumber)
        {
            if (resultNumber < 1 && resultNumber > searchResultPage.ReleaseDates.Count)
            {
                throw new ArgumentException($"Invalid search result number: {resultNumber}!");
            }

            var releaseDate = string.Empty;
            int counter = 1;
            foreach (var element in searchResultPage.ReleaseDates)
            {
                if (counter == resultNumber)
                {
                    releaseDate = element.Text;
                }
             
                counter++;
            }

            return releaseDate;
        }

        private static string GetReviewSummaryOf(int resultNumber)
        {
            if (resultNumber < 1 && resultNumber > searchResultPage.ReviewSummaries.Count)
            {
                throw new ArgumentException($"Invalid search result number: {resultNumber}!");
            }

            string result = string.Empty;
            int counter = 1;
            foreach (var element in searchResultPage.ReviewSummaries)
            {
                if (counter == resultNumber) 
                {
                    result = element.GetAttribute("data-tooltip-html");
                }

                counter++;
            }

            return result;
        }

        private static double GetPriceOf(int resultNumber)
        {
            if (resultNumber < 1 && resultNumber > searchResultPage.Prices.Count)
            {
                throw new ArgumentException($"Invalid search result number: {resultNumber}!");
            }

            double result = 0.0d;
            int counter = 1;
            foreach (var element in searchResultPage.Prices)
            {
                if (counter == resultNumber) 
                {
                    double.TryParse(element.Text, out result);
                }

                counter++;
            }

            return result;
        }
    }
}
