namespace ProjectStructure.Model
{
    public class SearchResult : IEquatable<SearchResult>
    {
        public string Name { get; set; }

        public List<string> Platforms { get; set; }

        public string RealeseDate { get; set; }

        public string ReviewSummary { get; set; }   

        public double Price { get; set; }

        public bool Equals(SearchResult? other)
        {
            if (this.Name == other.Name &&
                this.Platforms.SequenceEqual(other.Platforms) &&
                this.RealeseDate == other.RealeseDate &&
                this.ReviewSummary == other.ReviewSummary &&
                this.Price == other.Price)
            { 
                return true;
            }
         
            return false;
        }
    }
}
