using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GrokkingAlgorithms.Tests
{
    public class ListSorterTests
    {
        [Fact]
        public void GivenArrayOfItems_WhenSelectionSortIsInvoked_ThenSortedArrayIsReturned()
        {
            // Arrange
            var items = new List<ListSorter.Item>
            {
                new ListSorter.Item { Name = "A", Count = 5 },
                new ListSorter.Item { Name = "B", Count = 8 },
                new ListSorter.Item { Name = "C", Count = 1 },
                new ListSorter.Item { Name = "D", Count = 2 },
                new ListSorter.Item { Name = "E", Count = 7 },
            }.ToArray();

            // Act
            var result = ListSorter.SelectionSort(items);

            // Assert
            Assert.Equal("B,E,A,D,C", string.Join(",", result.Select(x => x.Name)));
        }
    }
}
