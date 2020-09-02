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

        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("1fd23", false)]
        [TestCase("0", false)]
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
            var binaryCheckService = new Business.Services.BinaryCheck.BinaryCheckService();

            //Act
            var result = binaryCheckService.Check(testData);

            //Assert

            Assert.AreEqual(result, expectedResult);
        }
    }
}