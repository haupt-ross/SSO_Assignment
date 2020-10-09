using NUnit.Framework;

namespace SSOAssignment.Test
{
    public class TextAnalyserTest
    {
        [Test]
        [TestCase("I like eating apples", " lieap")]
        [TestCase("john", null)]
        public void Find_WhenCalled_ReturnDuplicateCharacters(string input, string expected)
        {
            var result = TextAnalyser.FindDuplicates(input);
            StringAssert.AreEqualIgnoringCase(expected, result);
        }

        [Test]
        [TestCase("I like ??!!", "Ilike")]
        [TestCase("john", "john")]
        public void Find_WhenCalled_ReturnStringWithoutSpacesAndSpecialCharacters(string input, string expected)
        {
            var result = TextAnalyser.RemoveSpacesAndSpecialCharacters(input);
            StringAssert.AreEqualIgnoringCase(expected, result);
        }

        [Test]
        [TestCase("aateeIi", 4)]
        [TestCase("hhgj123", 0)]
        [TestCase("", 0)]
        public void Count_WhenCalled_ReturnCountOfDistinctVowelsInString(string input, int expected)
        {
            var result = TextAnalyser.CountDistinctVowels(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("Ross123?!!", "Ross")]
        public void Remove_WhenCalled_ReturnStringWithOnlyLetters(string input, string expected)
        {
            var result = TextAnalyser.RemoveSpacesAndSpecialCharacters(input);
            Assert.AreEqual(expected, result);
        }
    }
}