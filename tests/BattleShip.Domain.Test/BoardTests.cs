using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using BattleShip.Domain.Test.Data;
using Xunit;

namespace BattleShip.Domain.Test
{
    public class BoardTests
    {
        private readonly Board _board;
        private readonly IFixture _fixture;

        public BoardTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _fixture.Register(() => new Board(80, 40));

            _board = _fixture.Create<Board>();
        }

        [Theory]
        [ClassData(typeof(BoardIsNotVacantTestData))]
        public void IsVacant_Should_Return_False_If_Coordinates_Are_Occupied(
            IEnumerable<Coordinate> coordinatesToAddShip,
            IEnumerable<Coordinate> coordinatesToCheckIsVacant)
        {
            // Arrange
            var ship = new Ship(coordinatesToAddShip);
            _board.AddShip(ship);

            // Act
            var isVacant = _board.IsVacant(coordinatesToCheckIsVacant.Select(c => c.Location));

            // Assert
            Assert.False(isVacant);
        }

        [Theory]
        [ClassData(typeof(BoardIsVacantTestData))]
        public void IsVacant_Should_Return_True_If_Coordinates_Are_Vacant(
            IEnumerable<Coordinate> coordinatesToAddShip,
            IEnumerable<Coordinate> coordinatesToCheckIsVacant)
        {
            // Arrange
            var ship = new Ship(coordinatesToAddShip);
            _board.AddShip(ship);

            // Act
            var isVacant = _board.IsVacant(coordinatesToCheckIsVacant.Select(c => c.Location));

            // Assert
            Assert.True(isVacant);
        }

        [Fact]
        public void Should_Create_Board_With_Empty_Slots()
        {
            // Assert
            for (var row = 0; row < _board.Rows; row++)
            {
                for (var column = 0; column < _board.Columns; column++)
                {
                    Assert.True(string.IsNullOrWhiteSpace(_board.GetShipId(new Point(row, column))));
                }
            }
        }
    }
}