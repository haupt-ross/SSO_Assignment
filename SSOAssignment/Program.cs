using System;

namespace SSOAssignment
{
    class Program
    {
        private static int _distinctVowels;
        
        static void Main(string[] args)
        {
            Console.WriteLine(LangConstants.TextToAnalyse);
            var textToAnalyse = Console.ReadLine();
            var formattedTextToAnalyse = TextAnalyser.RemoveSpacesAndSpecialCharacters(textToAnalyse.ToLower());
            
            Console.WriteLine(LangConstants.OperationsRequired);
            var operationsRequired = Console.ReadLine();

            PerformOperations(operationsRequired, formattedTextToAnalyse);
        }

        private static void PerformOperations(string operationsRequired, string formattedInput)
        {
            const int cachedVowels = -1;
            
            if (operationsRequired.Contains("1"))
                CheckDuplicates(formattedInput);

            if (operationsRequired.Contains("2"))
                CountVowels(formattedInput);

            if (operationsRequired.Contains("3"))
                MoreVowelsOrConsonants(formattedInput, cachedVowels);
        }

        private static void CheckDuplicates(string input)
        {
            var duplicates = TextAnalyser.FindDuplicates(input);
            Console.WriteLine($"Found the following duplicates: {duplicates}");
        }

        private static int CountVowels(string input)
        {
            var vowels = _distinctVowels = TextAnalyser.CountDistinctVowels(input);
            Console.WriteLine($"The number of unique vowels is {vowels}");
            return vowels;
        }

        
        private static void MoreVowelsOrConsonants(string input, int cachedVowelCount)
        {
            var vowels = cachedVowelCount == -1 ? TextAnalyser.CountDistinctVowels(input) : cachedVowelCount ;
            var consonants = TextAnalyser.CountDistinctConsonants(input);

            if (vowels == consonants)
            {
                Console.WriteLine(LangConstants.EqualVowelsConsonantsOutput);
                return;
            }

            if (consonants > vowels)
            {
                Console.WriteLine(LangConstants.MoreConsonantsOutput);
                return;
            }
            
            Console.WriteLine(LangConstants.MoreVowelsOutput);
        }
    }
}