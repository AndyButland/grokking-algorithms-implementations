using Xunit;

namespace GrokkingAlgorithms.Tests
{
    public class FieldDividerTests
    {
        [Theory]
        [InlineData(80, 40, 40)]
        [InlineData(1680, 640, 80)]
        public void GivenFieldDimensions_WhenGetMaxSquareSizeInvoked_AnswerIsReturned(int length, int width, int expectedResult)
        {
            // Act
            var result = FieldDivider.GetMaxSquareSize(length, width);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
