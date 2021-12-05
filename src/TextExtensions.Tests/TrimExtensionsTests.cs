using NUnit.Framework;

namespace TextExtensions.Tests
{
    public class TrimExtensionsTests
    {
        [TestCase(null, null, null)]
        [TestCase("", null, "")]
        [TestCase("", "", "")]
        [TestCase("testData", "test", "Data")]
        [TestCase("testData", "extra", "testData")]

        public void should_trim_leading_text(string input, string toTrim, string expectedResult)
        {
            Assert.AreEqual(expectedResult, input.TrimStart(toTrim));
        }
        
        
        [TestCase(null, null, null)]
        [TestCase("", null, "")]
        [TestCase("", "", "")]
        [TestCase("testData", "Data", "test")]
        [TestCase("testData", "extra", "testData")]

        public void should_trim_trailing_text(string input, string toTrim, string expectedResult)
        {
            Assert.AreEqual(expectedResult, input.TrimEnd(toTrim));
        }
    }
}
