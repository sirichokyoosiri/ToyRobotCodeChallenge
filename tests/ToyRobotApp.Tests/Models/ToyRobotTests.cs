using Moq;
using TestUtilities.Extensions;
using ToyRobotApp.Interfaces;
using ToyRobotApp.Models;

namespace ToyRobotApp.Tests.Models
{
    public class ToyRobotTests
    {
        private readonly Mock<ITableTop> _tableTopMock;

        public ToyRobotTests()
        {
            _tableTopMock = new Mock<ITableTop>();
        }

        [Theory]
        [InlineData(0, 0, Direction.North)]
        [InlineData(1, 0, Direction.East)]
        [InlineData(0, 1, Direction.South)]
        [InlineData(2, 2, Direction.West)]
        public void Place_ValidPosition_ShouldSetPositionAndDirection(int x, int y, Direction facing)
        {
            // Arrange
            _tableTopMock
                .Setup(t => t.IsValidPosition(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);

            var toyRobot = new ToyRobot(_tableTopMock.Object);

            // Act
            toyRobot.Place(x, y, facing);

            // Assert
            Assert.Equal(x, toyRobot.GetX());
            Assert.Equal(y, toyRobot.GetY());
            Assert.Equal(facing, toyRobot.GetFacing());
        }

        [Theory]
        [InlineData(0, 0, Direction.North)]
        [InlineData(1, 0, Direction.East)]
        [InlineData(0, 1, Direction.South)]
        [InlineData(2, 2, Direction.West)]
        public void Place_InvalidPosition_ShouldNotSetPositionAndDirection(int x, int y, Direction facing)
        {
            // Arrange
            _tableTopMock
                .Setup(t => t.IsValidPosition(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(false);

            var toyRobot = new ToyRobot(_tableTopMock.Object);

            // Act
            toyRobot.Place(x, y, facing);

            // Assert
            Assert.Equal(-1, toyRobot.GetX());
            Assert.Equal(-1, toyRobot.GetY());
            Assert.Null(toyRobot.GetFacing());
        }

        [Fact]
        public void Move_WhenNotPlaced_ShouldNotChangePosition()
        {
            // Arrange
            var toyRobot = new ToyRobot(_tableTopMock.Object);

            // Act
            toyRobot.Move();

            // Assert
            Assert.Equal(-1, toyRobot.GetX());
            Assert.Equal(-1, toyRobot.GetY());
            Assert.Null(toyRobot.GetFacing());
        }

        [Theory]
        [InlineData(Direction.North, 2, 3)]
        [InlineData(Direction.East,  3, 2)]
        [InlineData(Direction.South, 2, 1)]
        [InlineData(Direction.West,  1, 2)]
        public void Move_WhenPlaced_ShouldMoveToValidPosition(Direction facing, int expectedX, int expectedY)
        {
            // Arrange
            _tableTopMock
                .Setup(t => t.IsValidPosition(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);

            var toyRobot = new ToyRobot(_tableTopMock.Object);
            toyRobot.Place(2, 2, facing);

            // Act
            toyRobot.Move();

            // Assert
            Assert.Equal(expectedX, toyRobot.GetX());
            Assert.Equal(expectedY, toyRobot.GetY());
            Assert.Equal(facing, toyRobot.GetFacing());
        }

        [Theory]
        [InlineData(Direction.North)]
        [InlineData(Direction.East)]
        [InlineData(Direction.South)]
        [InlineData(Direction.West)]
        public void Move_WhenPlacedAndWouldFall_ShouldNotMove(Direction facing)
        {
            // Arrange
            _tableTopMock
                .Setup(t => t.IsValidPosition(2, 2))
                .Returns(true);

            var toyRobot = new ToyRobot(_tableTopMock.Object);
            toyRobot.Place(2, 2, facing);

            // Act
            toyRobot.Move();

            // Assert
            Assert.Equal(2, toyRobot.GetX());
            Assert.Equal(2, toyRobot.GetY());
            Assert.Equal(facing, toyRobot.GetFacing());
        }

        [Fact]
        public void TurnLeft_WhenNotPlaced_ShouldNotChangeDirection()
        {
            // Arrange
            var toyRobot = new ToyRobot(_tableTopMock.Object);

            // Act
            toyRobot.TurnLeft();

            // Assert
            Assert.Equal(-1, toyRobot.GetX());
            Assert.Equal(-1, toyRobot.GetY());
            Assert.Null(toyRobot.GetFacing());
        }

        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.East, Direction.North)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.West, Direction.South)]
        public void TurnLeft_WhenPlaced_ShouldTurnLeft(Direction facing, Direction expectedFacing)
        {
            // Arrange
            _tableTopMock
                .Setup(t => t.IsValidPosition(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);

            var toyRobot = new ToyRobot(_tableTopMock.Object);
            toyRobot.Place(2, 2, facing);

            // Act
            toyRobot.TurnLeft();

            // Assert
            Assert.Equal(2, toyRobot.GetX());
            Assert.Equal(2, toyRobot.GetY());
            Assert.Equal(expectedFacing, toyRobot.GetFacing());
        }

        [Theory]
        [InlineData(Direction.North)]
        [InlineData(Direction.East)]
        [InlineData(Direction.South)]
        [InlineData(Direction.West)]
        public void TurnRight_WhenNotPlaced_ShouldNotChangeDirection(Direction facing)
        {
            // Arrange
            var toyRobot = new ToyRobot(_tableTopMock.Object);

            // Act
            toyRobot.TurnRight();

            // Assert
            Assert.Equal(-1, toyRobot.GetX());
            Assert.Equal(-1, toyRobot.GetY());
            Assert.Null(toyRobot.GetFacing());
        }

        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.East, Direction.South)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.West, Direction.North)]
        public void TurnRight_WhenPlaced_ShouldTurnRight(Direction facing, Direction expectedFacing)
        {
            // Arrange
            _tableTopMock
                .Setup(t => t.IsValidPosition(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);

            var toyRobot = new ToyRobot(_tableTopMock.Object);
            toyRobot.Place(2, 2, facing);

            // Act
            toyRobot.TurnRight();

            // Assert
            Assert.Equal(2, toyRobot.GetX());
            Assert.Equal(2, toyRobot.GetY());
            Assert.Equal(expectedFacing, toyRobot.GetFacing());
        }

        [Fact]
        public void Report_WhenNotPlaced_ShouldReturnEmptyString()
        {
            // Arrange
            var toyRobot = new ToyRobot(_tableTopMock.Object);

            // Act
            var actualOutput = toyRobot.Report();

            // Assert
            Assert.Equal(string.Empty, actualOutput);
        }

        [Theory]
        [InlineData(0, 0, Direction.North, "Output: 0,0,NORTH")]
        [InlineData(1, 0, Direction.East, "Output: 1,0,EAST")]
        [InlineData(0, 1, Direction.South, "Output: 0,1,SOUTH")]
        [InlineData(2, 2, Direction.West, "Output: 2,2,WEST")]
        public void Report_WhenPlaced_ShouldReturnPositionAndDirection(int x, int y, Direction facing, string expectedOutput)
        {
            // Arrange
            _tableTopMock
                .Setup(t => t.IsValidPosition(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);

            var toyRobot = new ToyRobot(_tableTopMock.Object);
            toyRobot.Place(x, y, facing);

            // Act
            var actualOutput = toyRobot.Report();

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
