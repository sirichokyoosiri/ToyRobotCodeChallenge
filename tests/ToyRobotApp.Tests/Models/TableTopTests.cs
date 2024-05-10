using ToyRobotApp.Models;

namespace ToyRobotApp.Tests.Models
{
    public class TableTopTests
    {
        [Theory]
        [InlineData(-1, 5)]
        [InlineData(5, -1)]
        [InlineData(0, 5)]
        [InlineData(5, 0)]
        public void Constructor_InvalidDimensions_ShouldThrowArgumentException(int width, int height)
        {
            // Arrange & Act
            var exception = Assert.Throws<ArgumentException>(() => new TableTop(width, height));

            // Assert
            Assert.Equal("TableTop dimensions must be positive values.", exception.Message);
        }

        [Theory]
        [InlineData(1, 5)]
        [InlineData(5, 1)]
        [InlineData(5, 5)]
        public void Constructor_ValidDimensions_ShouldCreateInstance(int width, int height)
        {
            // Arrange & Act
            var tableTop = new TableTop(width, height);

            // Assert
            Assert.NotNull(tableTop);
        }

        [Theory]
        [InlineData(5, 5, 0, 0, true)]
        [InlineData(5, 5, 4, 4, true)]
        [InlineData(5, 5, -1, 0, false)]
        [InlineData(5, 5, 0, -1, false)]
        [InlineData(5, 5, 5, 5, false)]
        public void IsValidPosition_ValidAndInvalidPositions_ShouldReturnExpectedResult(int width, int height, int x, int y, bool expectedResult)
        {
            // Arrange
            var tableTop = new TableTop(width, height);

            // Act
            bool result = tableTop.IsValidPosition(x, y);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
