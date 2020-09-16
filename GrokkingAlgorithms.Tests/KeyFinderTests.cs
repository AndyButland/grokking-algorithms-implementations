using System.Collections.Generic;
using Xunit;

namespace GrokkingAlgorithms.Tests
{
    public class KeyFinderTests
    {
        [Fact]
        public void GivenSetOfBoxesContainingKey_WhenFindWithLoopIsInvoked_ThenKeyWithBoxIsReturned()
        {
            // Arrange
            var box = GetBox(withKey: true);

            // Act
            var result = KeyFinder.FindWithLoop(box);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.HasKey);
        }

        [Fact]
        public void GivenSetOfBoxesNotContainingKey_WhenFindWithLoopIsInvoked_ThenNullIsReturned()
        {
            // Arrange
            var box = GetBox();

            // Act
            var result = KeyFinder.FindWithLoop(box);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GivenSetOfBoxesContainingKey_WhenFindWithRecursionIsInvoked_ThenKeyWithBoxIsReturned()
        {
            // Arrange
            var box = GetBox(withKey: true);

            // Act
            var result = KeyFinder.FindWithRecursion(box);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.HasKey);
        }

        [Fact]
        public void GivenSetOfBoxesNotContainingKey_WhenFindWithRecursionIsInvoked_ThenNullIsReturned()
        {
            // Arrange
            var box = GetBox();

            // Act
            var result = KeyFinder.FindWithRecursion(box);

            // Assert
            Assert.Null(result);
        }

        private static KeyFinder.Box GetBox(bool withKey = false)
        {
            return new KeyFinder.Box
            {
                Boxes = new KeyFinder.Box[]
                {
                    new KeyFinder.Box(),
                    new KeyFinder.Box
                    {
                        Boxes = new KeyFinder.Box[]
                        {
                            new KeyFinder.Box
                            {
                                Boxes = new KeyFinder.Box[]
                                {
                                    new KeyFinder.Box(),
                                    new KeyFinder.Box { HasKey = withKey },
                                },
                            }
                        }
                    },
                }
            };
        }
    }
}
