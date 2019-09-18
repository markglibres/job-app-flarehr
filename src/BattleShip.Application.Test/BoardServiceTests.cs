using BattleShip.Application.Services;
using BattleShip.Domain.Constants;
using BattleShip.Domain.SeedWork;
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

        [Fact]
        public void Should_Create_Empty_Board()
        {
            // Assert
            Assert.NotNull(_board);

            for (var row = 0; row < _board.Rows; row++)
            {
                for (var column = 0; column < _board.Columns; column++)
                {
                    Assert.True(string.IsNullOrWhiteSpace(_board.GetShipId(row, column)));
                }
            }
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

        [Fact]
        public void Should_Return_True_When_Creating_Ship()
        {
            // Act
            var isSuccess = _boardService
                .AddShip(
                    _board,
                    BoardOrientation.Vertical,
                    0,
                    10);

            // Assert
            Assert.True(isSuccess);
        }
    }
}