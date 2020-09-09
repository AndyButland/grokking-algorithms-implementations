using System.Linq;
using Xunit;

namespace GrokkingAlgorithms.Tests
{
    public class NumberSearcherTests
    {
        [Theory]
        [InlineData(7)]
        [InlineData(54)]
        [InlineData(99)]
        public void GivenNeedleInHaystack_WhenSimpleSearchIsInvoked_ThenIndexOfNeedleIsReturned(int needle)
        {
            // Arrange
            var haystack = Enumerable.Range(1, 100).ToArray();

            // Act
            var result = NumberSearcher.SimpleSearch(haystack, needle);

            // Assert
            Assert.Equal(needle - 1, result); // Index is 0 based, so e.g. number 99 is at position 98.
        }

        [Fact]
        public void GivenNeedleNotInHaystack_WhenSimpleSearchIsInvoked_ThenNotFoundValueIsReturned()
        {
            // Arrange
            var haystack = Enumerable.Range(1, 100).ToArray();
            var needle = 101;

            // Act
            var result = NumberSearcher.SimpleSearch(haystack, needle);

            // Assert
            Assert.Equal(-1, result);
        }

        [Theory]
        [InlineData(7)]
        [InlineData(54)]
        [InlineData(99)]
        public void GivenNeedleInHaystack_WhenBinarySearchIsInvoked_ThenIndexOfNeedleIsReturned(int needle)
        {
            // Arrange
            var haystack = Enumerable.Range(1, 100).ToArray();

            // Act
            var result = NumberSearcher.BinarySearch(haystack, needle);

            // Assert
            Assert.Equal(needle - 1, result); // Index is 0 based, so e.g. number 99 is at position 98.
        }

        [Fact]
        public void GivenNeedleNotInHaystack_WhenBinarySearchIsInvoked_ThenNotFoundValueIsReturned()
        {
            // Arrange
            var haystack = Enumerable.Range(1, 100).ToArray();
            var needle = 101;

            // Act
            var result = NumberSearcher.BinarySearch(haystack, needle);

            // Assert
            Assert.Equal(-1, result);
        }
    }
}
