using System.Linq;
using System.Text.RegularExpressions;

namespace SSOAssignment
{
    public static class TextAnalyser
    {
        public static string FindDuplicates(string input)
        {
            var duplicates = input.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            var result = new string(duplicates.ToArray());
            return result.Length > 0 ? result : null;
        }

        public static int CountDistinctVowels(string input)
        {
            var result =  input.Where(c => "aeiouAEIOU".Contains(c)).Distinct().ToList();
            return result.Count;
        }

        public static int CountDistinctConsonants(string input)
        {
            var result =  input.Where(c => "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPRSTVWXYZ".Contains(c)).Distinct().ToList();
            return result.Count;
        }

        public static string RemoveSpacesAndSpecialCharacters(string input)
        {
            return Regex.Replace(input, @"[^a-zA-Z]+", "");
        }
    }
}