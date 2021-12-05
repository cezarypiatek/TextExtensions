using NUnit.Framework;

namespace TextExtensions.Tests
{
    public class CaseExtensionsTests
    {
        [TestCase(null, null)]
        [TestCase("","")]
        [TestCase("a","A")]
        [TestCase("ab","Ab")]
        [TestCase("test data","TestData")]
        [TestCase("TestData","TestData")]
        [TestCase("testData","TestData")]
        [TestCase("test_data","TestData")]
        [TestCase("test\r\ndata","TestData")]
        public void should_convert_to_pascal_case(string input, string expectedResult)
        {
            Assert.AreEqual(expectedResult, input.ToPascalCase());
        }
        
        [TestCase(null, null)]
        [TestCase("","")]
        [TestCase("a","a")]
        [TestCase("ab","ab")]
        [TestCase("test data","testData")]
        [TestCase("test data extra","testDataExtra")]
        [TestCase("TestData","testData")]
        [TestCase("testData","testData")]
        [TestCase("test_data","testData")]
        [TestCase("test\r\ndata", "testData")]
        public void should_convert_to_camel_case(string input, string expectedResult)
        {
            Assert.AreEqual(expectedResult, input.ToCamelCase());
        }
        
        
        [TestCase(null, null)]
        [TestCase("","")]
        [TestCase("a","a")]
        [TestCase("ab","ab")]
        [TestCase("test data","test_data")]
        [TestCase("TestData","test_data")]
        [TestCase("test data extra", "test_data_extra")]
        [TestCase("testData","test_data")]
        [TestCase("test_data","test_data")]
        [TestCase("test-data","test_data")]
        [TestCase("test-DATA","test_data")]
        [TestCase("test\r\nDATA", "test_data")]
        public void should_convert_to_snake_case(string input, string expectedResult)
        {
            Assert.AreEqual(expectedResult, input.ToSnakeCase());
        }
        
        [TestCase(null, null)]
        [TestCase("","")]
        [TestCase("a","a")]
        [TestCase("ab","ab")]
        [TestCase("test data","test-data")]
        [TestCase("TestData","test-data")]
        [TestCase("test data extra", "test-data-extra")]
        [TestCase("testData","test-data")]
        [TestCase("test_data","test-data")]
        [TestCase("test-data","test-data")]
        [TestCase("test-DATA","test-data")]
        public void should_convert_to_kebab_case(string input, string expectedResult)
        {
            Assert.AreEqual(expectedResult, input.ToKebabCase());
        }
    }
}
