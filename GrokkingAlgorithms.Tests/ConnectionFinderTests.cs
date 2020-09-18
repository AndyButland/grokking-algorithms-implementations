using Xunit;

namespace GrokkingAlgorithms.Tests
{
    public class ConnectionFinderTests
    {
        [Fact]
        public void GivenNodesWithoutMatchingCompany_WhenFindConnectionWorkingForIsInvoked_NullIsReturned()
        {
            // Arrange
            var node = GetNodes();
            const string Company = "X";

            // Act
            var result = ConnectionFinder.FindConnectionWorkingFor(node, Company);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GivenNodesWithMatchingCompany_WhenFindConnectionWorkingForIsInvoked_NullIsReturned()
        {
            // Arrange
            var node = GetNodes();
            const string Company = "F";

            // Act
            var result = ConnectionFinder.FindConnectionWorkingFor(node, Company);

            // Assert
            Assert.Equal("Harry", result.Name);
        }

        private ConnectionFinder.Node GetNodes()
        {
            return new ConnectionFinder.Node
            {
                Connections = new ConnectionFinder.Node[]
                {
                    new ConnectionFinder.Node
                    {
                        Id = 1,
                        Name = "Alice",
                        Company = "A",
                        Connections = new ConnectionFinder.Node[]
                        {
                            new ConnectionFinder.Node
                            {
                                Id = 2,
                                Name = "Bob",
                                Company = "B",
                            },
                            new ConnectionFinder.Node
                            {
                                Id = 5,
                                Name = "Elizabeth",
                                Company = "E",
                            },
                            new ConnectionFinder.Node
                            {
                                Id = 3,
                                Name = "Charlie",
                                Company = "A",
                                Connections = new ConnectionFinder.Node[]
                                {
                                    new ConnectionFinder.Node
                                    {
                                        Id = 4,
                                        Name = "Derek",
                                        Company = "C",
                                    },
                                    new ConnectionFinder.Node
                                    {
                                        Id = 5,
                                        Name = "Elizabeth",
                                        Company = "E",
                                    },
                                    new ConnectionFinder.Node
                                    {
                                        Id = 10,
                                        Name = "Jane",
                                        Company = "A",
                                    },
                                }
                            }
                        }
                    },
                    new ConnectionFinder.Node
                    {
                        Id = 6,
                        Name = "Fred",
                        Company = "A",
                    },
                    new ConnectionFinder.Node
                    {
                        Id = 7,
                        Name = "Gertrude",
                        Company = "A",
                        Connections = new ConnectionFinder.Node[]
                        {
                            new ConnectionFinder.Node
                            {
                                Id = 8,
                                Name = "Harry",
                                Company = "F",
                                Connections = new ConnectionFinder.Node[]
                                {
                                    new ConnectionFinder.Node
                                    {
                                        Id = 9,
                                        Name = "Ivy",
                                        Company = "C",
                                    },
                                }
                            },
                            new ConnectionFinder.Node
                            {
                                Id = 10,
                                Name = "Jane",
                                Company = "A",
                            }
                        }
                    }
                }
            };
        }
    }
}
