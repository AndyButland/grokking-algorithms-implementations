using System.Collections.Generic;
using Xunit;

namespace GrokkingAlgorithms.Tests
{
    public class RadioStationOptimizerTests
    {
        [Fact]
        public void GivenStatesAndStations_WhenSelectStationsIsInvoked_ReturnsCorrectSetOfStations()
        {
            // Arrange
            var states = new[] { "mt", "wa", "id", "or", "ca", "nv", "ut", "az" };
            var stations = new Dictionary<string, HashSet<string>>()
            {
                { "S1", new HashSet<string> { "id", "nv", "ut" } },
                { "S2", new HashSet<string> { "wa", "id", "mt" } },
                { "S3", new HashSet<string> { "or", "nv", "ca" } },
                { "S4", new HashSet<string> { "nv", "ut" } },
                { "S5", new HashSet<string> { "ca", "az" } },
            };

            // Act
            var result = RadioStationOptimizer.SelectStations(states, stations);

            // Assert
            Assert.Equal("S1,S2,S3,S5", string.Join(",", result));
        }
    }
} 