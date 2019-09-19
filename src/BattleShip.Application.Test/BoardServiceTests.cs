using System.Collections.Generic;
using System.Drawing;
using BattleShip.Application.Constants;
using BattleShip.Application.Services;
using BattleShip.Application.Test.Data;
using BattleShip.Domain.SeedWork;
using Moq;
using Xunit;

namespace BattleShip.Application.Test
{
    public class BoardServiceTests
    {
        private readonly Board80X40 _boardService;
        private readonly IBoard _board;

        public BoardServiceTests()
        {
            // Arrange
            _boardService = new Board80X40();

            _board = _boardService.CreateBoard();
        }

        [Theory]
        [ClassData(typeof(BoardServiceCoordinatesTestData))]
        public void Should_Calculate_Coordinates(
            BoardOrientation orientation,
            int startRow,
            int startColumn,
            int length,
            IEnumerable<Point> expectedPoints)
        {
            // Arrange
            var fakeBoard = new Mock<IBoard>();
            var location = new List<Point>();
            fakeBoard.Setup(board => board.IsVacant(It.IsAny<IEnumerable<Point>>()))
                .Callback((IEnumerable<Point> coordinates) => { location.AddRange(coordinates); })
                .Returns(true);
            fakeBoard.Setup(board => board.AddShip(It.IsAny<IShip>()))
                .Returns(true);

            // Act
            _boardService
                .AddShip(
                    fakeBoard.Object,
                    orientation,
                    startRow,
                    startColumn,
                    length);

            // Assert
            Assert.All(expectedPoints,
                point => { Assert.Contains(point, location); });
        }

        [Fact]
        public void Should_Create_Board()
        {
            // Assert
            Assert.NotNull(_board);
        }

        [Fact]
        public void Should_Create_Ship_If_Coordinates_Are_Vacant()
        {
            // Arrange
            var fakeBoard = new Mock<IBoard>();
            fakeBoard.Setup(board => board.AddShip(It.IsAny<IShip>()))
                .Returns(true);
            fakeBoard.Setup(board => board.IsVacant(It.IsAny<IEnumerable<Point>>()))
                .Returns(true);
            // Act
            _boardService
                .AddShip(
                    fakeBoard.Object,
                    BoardOrientation.Vertical,
                    10,
                    15,
                    10);

            // Assert
            fakeBoard.Verify(board => board.AddShip(It.IsAny<IShip>()), Times.Once);
        }

        [Fact]
        public void Should_Not_Create_Ship_If_Coordinates_Are_Occupied()
        {
            // Arrange
            var fakeBoard = new Mock<IBoard>();
            fakeBoard.Setup(board => board.AddShip(It.IsAny<IShip>()))
                .Returns(false);
            fakeBoard.Setup(board => board.IsVacant(It.IsAny<IEnumerable<Point>>()))
                .Returns(false);
            // Act
            _boardService
                .AddShip(
                    fakeBoard.Object,
                    BoardOrientation.Vertical,
                    10,
                    15,
                    10);

            // Assert
            fakeBoard.Verify(board => board.AddShip(It.IsAny<IShip>()), Times.Never);
        }

        [Fact]
        public void Should_Return_False_If_No_Hit()
        {
            // Act
            var hit = _boardService.Attack(_board,
                10,
                15);

            Assert.False(hit);
        }

        [Fact]
        public void Should_Return_False_If_Not_All_Ships_Are_Sunk()
        {
            // Act
            var sunk = _boardService.IsSunk(_board);

            // Assert
            Assert.False(sunk);
        }
    }
}