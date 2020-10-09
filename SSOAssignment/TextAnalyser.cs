using System.Linq;
using System.Text.RegularExpressions;

namespace SSOAssignment
{
    public static class TextAnalyser
    {
        /// <summary>
        /// Finds duplicate characters in a string
        /// </summary>
        /// <param name="input">string to be analysed</param>
        /// <returns>string of the duplicate characters</returns>
        public static string FindDuplicates(string input)
        {
            var duplicates = input.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            var result = new string(duplicates.ToArray());
            return result.Length > 0 ? result : null;
        }

        /// <summary>
        /// Counts the number of distinct vowels in a string
        /// </summary>
        /// <param name="input">string to be analysed</param>
        /// <returns>count of the number of distinct vowels</returns>
        public static int CountDistinctVowels(string input)
        {
            var result =  input.Where(c => "aeiouAEIOU".Contains(c)).Distinct().ToList();
            return result.Count;
        }

        /// <summary>
        /// Counts the number of distinct consonants in a string
        /// </summary>
        /// <param name="input">string to be analysed</param>
        /// <returns>count of the number of distinct consonants</returns>
        public static int CountDistinctConsonants(string input)
        {
            var result =  input.Where(c => "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPRSTVWXYZ".Contains(c)).Distinct().ToList();
            return result.Count;
        }

        /// <summary>
        /// Remove all non letter characters from a string
        /// </summary>
        /// <param name="input">string to be analysed</param>
        /// <returns>string stripped of all special characters, numbers and spaces</returns>
        public static string RemoveSpacesAndSpecialCharacters(string input)
        {
            return Regex.Replace(input, @"[^a-zA-Z]+", "");
        }
    }
}