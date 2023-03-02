namespace FrameworkAndProjectStructure.Utility
{
    public class StringUtil
    {
        public static string Letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Numbers = "012345679";

        public static string SpecialCharacters = "~!@#$%^&*()_+|";

        private static readonly Random Random = new Random();

        public static string GenerateRandomString(int length, bool IsLettersAllowed = true,
                                                              bool IsNumbersAllowed = true, 
                                                              bool IsSpecialCharactersAllowed = true)
        {
            var result = new System.Text.StringBuilder();
            int numberOfChars = 0;

            if (length < 1)
            {
                throw new ArgumentException("Password length must be positive!");
            }

            for (int i = 0; i < length; i++)
            {
                if (numberOfChars < length && IsLettersAllowed)
                {
                    result.Append(Numbers[Random.Next(Numbers.Length)]);
                    numberOfChars++;
                }

                if (numberOfChars < length && IsNumbersAllowed)
                {
                    result.Append(Letters[Random.Next(Letters.Length)]);
                    numberOfChars++;
                }

                if (numberOfChars < length && IsSpecialCharactersAllowed)
                {
                    result.Append(SpecialCharacters[Random.Next(SpecialCharacters.Length)]);
                    numberOfChars++;
                }
            }

            return result.ToString();
        }
    }
}
