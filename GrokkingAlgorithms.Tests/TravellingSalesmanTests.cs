using System;
using System.Collections.Generic;
using Xunit;

namespace GrokkingAlgorithms.Tests
{
    public class TravellingSalesmanTests
    {
        [Theory]
        [InlineData(1, "A,B,C", 6)]
        [InlineData(2, "B,A,C", 3)]
        [InlineData(3, "B,D,A,C", 7)]
        public void GivenGraph_WhenGetCheapestPathIsInvoked_NullIsReturned(int graphNumber, string expectedPath, int expectedWeight)
        {
            // Arrange
            var graph = GetGraph(graphNumber);            

            // Act
            var result = TravellingSalesman.GetCheapestPathThroughAllPoints(graph);

            // Assert
            Assert.Equal(expectedPath, result.Path);
            Assert.Equal(expectedWeight, result.Weight);
        }

        private Dictionary<string, Dictionary<string, int>> GetGraph(int graphNumber)
        {
            switch (graphNumber)
            {
                case 1:
                    return new Dictionary<string, Dictionary<string, int>>
                    {
                        {
                            "A",
                            new Dictionary<string, int>
                            {
                                { "B", 2 },
                                { "C", 6 },
                            }
                        },
                        {
                            "B",
                            new Dictionary<string, int>
                            {
                                { "A", 2 },
                                { "C", 4 },
                            }
                        },
                        {
                            "C",
                            new Dictionary<string, int>
                            {
                                { "A", 6 },
                                { "B", 4 },                                
                            }
                        },
                    };
                case 2:
                    return new Dictionary<string, Dictionary<string, int>>
                    {
                        {
                            "A",
                            new Dictionary<string, int>
                            {
                                { "B", 2 },
                                { "C", 1 },
                            }
                        },
                        {
                            "B",
                            new Dictionary<string, int>
                            {
                                { "A", 2 },
                                { "C", 4 },
                            }
                        },
                        {
                            "C",
                            new Dictionary<string, int>
                            {
                                { "A", 1 },
                                { "B", 4 },                                
                            }
                        },
                    };
                case 3:
                    return new Dictionary<string, Dictionary<string, int>>
                    {
                        {
                            "A",
                            new Dictionary<string, int>
                            {
                                { "B", 5 },
                                { "C", 2 },
                                { "D", 1 },
                            }
                        },
                        {
                            "B",
                            new Dictionary<string, int>
                            {
                                { "A", 5 },
                                { "C", 6 },
                                { "D", 4 },
                            }
                        },
                        {
                            "C",
                            new Dictionary<string, int>
                            {
                                { "A", 2 },
                                { "B", 6 },
                                { "D", 3 },
                            }
                        },
                        {
                            "D",
                            new Dictionary<string, int>
                            {
                                { "A", 1 },
                                { "B", 4 },
                                { "C", 3 },
                            }
                        },
                    };

                default:
                    throw new ArgumentOutOfRangeException(nameof(graphNumber));
            }
        }
    }
}
