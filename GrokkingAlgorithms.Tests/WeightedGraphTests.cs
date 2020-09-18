using System;
using System.Collections.Generic;
using Xunit;

namespace GrokkingAlgorithms.Tests
{
    public class WeightedGraphTests
    {
        [Theory]
        [InlineData(1, "Start,B,A,Finish", 6)]
        [InlineData(2, "Start,A,D,Finish", 8)]
        [InlineData(3, "Start,A,C,Finish", 60)]
        public void GivenGraph_WhenFindConnectionWorkingForIsInvoked_NullIsReturned(int graphNumber, string expectedPath, int expectedWeight)
        {
            // Arrange
            var graph = GetGraph(graphNumber);            

            // Act
            var result = WeightedGraph.GetCheapestPath(graph);

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
                            "Start",
                            new Dictionary<string, int>
                            {
                                { "A", 6 },
                                { "B", 2 },
                            }
                        },
                        {
                            "A",
                            new Dictionary<string, int>
                            {
                                { "Finish", 1 },
                            }
                        },
                        {
                            "B",
                            new Dictionary<string, int>
                            {
                                { "A", 3 },
                                { "Finish", 5 },
                            }
                        },
                        {
                            "Finish",
                            new Dictionary<string, int>()
                        }
                    };
                case 2:
                    return new Dictionary<string, Dictionary<string, int>>
                    {
                        {
                            "Start",
                            new Dictionary<string, int>
                            {
                                { "A", 5 },
                                { "B", 2 },
                            }
                        },
                        {
                            "A",
                            new Dictionary<string, int>
                            {
                                { "C", 4 },
                                { "D", 2 },
                            }
                        },
                        {
                            "B",
                            new Dictionary<string, int>
                            {
                                { "A", 8 },
                                { "D", 7 },
                            }
                        },
                        {
                            "C",
                            new Dictionary<string, int>
                            {
                                { "Finish", 3 },
                                { "D", 6 },
                            }
                        },
                        {
                            "D",
                            new Dictionary<string, int>
                            {
                                { "Finish", 1 },
                            }
                        },
                        {
                            "Finish",
                            new Dictionary<string, int>()
                        }
                    };
                case 3:
                    return new Dictionary<string, Dictionary<string, int>>
                    {
                        {
                            "Start",
                            new Dictionary<string, int>
                            {
                                { "A", 10 },
                            }
                        },
                        {
                            "A",
                            new Dictionary<string, int>
                            {
                                { "C", 20 },
                            }
                        },
                        {
                            "B",
                            new Dictionary<string, int>
                            {
                                { "A", 1 },
                            }
                        },
                        {
                            "C",
                            new Dictionary<string, int>
                            {
                                { "Finish", 30 },
                                { "B", 1 },
                            }
                        },
                        {
                            "Finish",
                            new Dictionary<string, int>()
                        }
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(graphNumber));
            }
        }
    }
}
