using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using BattleShip.Domain.Constants;
using BattleShip.Domain.SeedWork;
using BattleShip.Domain.Test.Data;
using Moq;
using Moq.Protected;
using Xunit;

namespace BattleShip.Domain.Test
{
    public class BoardTests
    {
        private readonly IFixture _fixture;

        public BoardTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _fixture.Register(() => new Board(80, 40));
           
        }

        [Theory]
        [ClassData(typeof(BoardIsNotVacantTestData))]
        public void IsVacant_Should_Return_False_If_Coordinates_Are_Occupied(
            IEnumerable<Coordinate> coordinatesToAddShip,
            IEnumerable<Coordinate> coordinatesToCheckIsVacant)
        {
            // Arrange
            var ship = new Ship(coordinatesToAddShip);
            var board = _fixture.Create<Board>();

            board.AddShip(ship);

            // Act
            var isVacant = board.IsVacant(coordinatesToCheckIsVacant.Select(c => c.Location));

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
            var board = _fixture.Create<Board>();
            board.AddShip(ship);

            // Act
            var isVacant = board.IsVacant(coordinatesToCheckIsVacant.Select(c => c.Location));

            // Assert
            Assert.True(isVacant);
        }

        [Fact]
        public void Should_Create_Board_With_Empty_Slots()
        {
            // Arrange
            var board = _fixture.Create<Board>();

            // Assert
            for (var row = 0; row < board.Rows; row++)
            {
                for (var column = 0; column < board.Columns; column++)
                {
                    Assert.True(string.IsNullOrWhiteSpace(board.GetShipId(new Point(row, column))));
                }
            }
        }

        [Fact]
        public void IsSunk_Should_Return_False_If_Not_All_Ships_Sunk()
        {
            // Arrange
            
            var operationalShip = _fixture.Create<IShip>();
            var sunkShip = _fixture.Create<IShip>();
            Mock.Get(operationalShip)
                .SetupGet(s => s.Status)
                .Returns(ShipStatus.Operational);
            Mock.Get(sunkShip)
                .SetupGet(s => s.Status)
                .Returns(ShipStatus.Sunk);

            var board = _fixture.Create<Board>();
            board.AddShip(operationalShip);
            board.AddShip(sunkShip);

            // Act
            var isSunk = board.IsSunk();

            // Arrange
            Assert.False(isSunk);
        }

        [Fact]
        public void IsSunk_Should_Return_True_If_All_Ships_Sunk()
        {
            // Arrange

            var sunkShip1 = _fixture.Create<IShip>();
            var sunkShip2 = _fixture.Create<IShip>();
            Mock.Get(sunkShip1)
                .SetupGet(s => s.Status)
                .Returns(ShipStatus.Sunk);
            Mock.Get(sunkShip2)
                .SetupGet(s => s.Status)
                .Returns(ShipStatus.Sunk);

            var board = _fixture.Create<Board>();
            board.AddShip(sunkShip1);
            board.AddShip(sunkShip2);
            
            // Act
            var isSunk = board.IsSunk();

            // Arrange
            Assert.True(isSunk);
        }
    }
}