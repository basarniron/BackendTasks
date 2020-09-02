using NUnit.Framework;

namespace BackendTask.BinaryCheckService.UnitTests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("101011", false)]
        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("1fd23", false)]
        [TestCase("0", false)]
        [TestCase("1", false)]
        [TestCase("00", false)]
        [TestCase("11", false)]
        [TestCase("10", true)]
        [TestCase("01", true)]
        [TestCase("101", false)]
        [TestCase("010", false)]
        [TestCase("10101", false)]
        [TestCase("101011", false)]
        [TestCase("101010", true)]
        [TestCase("11010", false)]
        [TestCase("110010", true)]
        [TestCase("1100010101", false)]
        [TestCase("1100101011100010101011000101010110001011", false)]
        [Test]
        public void Test1(string testData, bool expectedResult)
        {
            //Arrange

            //Act
            var result = Business.Services.BinaryCheck.BinaryCheckService.Check(testData);

            //Assert
            Assert.AreEqual(result, expectedResult);
        }
    }
}