using Xunit;

namespace GrokkingAlgorithms.Tests
{
    public class NumberSumTests
    {
        [Fact]
        public void GivenArrayOfNumbers_WhenSumWithLoopInvoked_SumIsReturned()
        {
            // Arrange
            var numbers = new[] { 2, 4, 6, 8 };

            // Act
            var result = NumberSum.SumWithLoop(numbers);

            // Assert
            Assert.Equal(20, result);
        }

        [Fact]
        public void GivenArrayOfNumbers_WhenSumWithRecursionInvoked_SumIsReturned()
        {
            // Arrange
            var numbers = new[] { 2, 4, 6, 8 };

            // Act
            var result = NumberSum.SumWithLoop(numbers);

            // Assert
            Assert.Equal(20, result);
        }
    }
}
