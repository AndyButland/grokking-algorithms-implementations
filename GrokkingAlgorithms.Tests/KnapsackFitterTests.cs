using Xunit;

namespace GrokkingAlgorithms.Tests
{
    public class KnapsackFitterTests
    {
        [Fact]
        public void GivenKnapsackAndItems_WhenGetMaxValueIsInvoked_NullIsReturned()
        {
            // Arrange
            const int KnapsackSize = 4;
            var items = new[]
            {
                new KnapsackFitter.Item { Name = "A", Value = 1500, Weight = 1 },
                new KnapsackFitter.Item { Name = "B", Value = 3000, Weight = 4 },
                new KnapsackFitter.Item { Name = "C", Value = 2000, Weight = 3 },
            };

            // Act
            var result = KnapsackFitter.GetMaxValue(KnapsackSize, items);

            // Assert
            Assert.Equal(3500, result.Value);
            Assert.Equal("A,C", result.Items);
        }

    }
}
