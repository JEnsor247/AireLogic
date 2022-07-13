using FluentAssertions;
using NUnit.Framework;

namespace AireLogic_TechTest.Tests
{
    [TestFixture]
    public class CalculationsTest
    {
        [TestCase(15,5,3)]
        [TestCase(500,15,33)]
        public void CalculatedAverageShouldMatchExpected(int sum, int total, int expectedResult)
        {
            var result = sum / total;
            result.Should().Be(expectedResult);
        }
    }
}
