using System.Collections.Generic;
using System.Drawing;
using BattleShip.Application.Constants;
using BattleShip.Application.Test.SeedWork;
using BattleShip.Domain.SeedWork;
using Moq;
using Xunit;

namespace BattleShip.Application.Test
{
    public class WhenAddingShipAndCoordinatesAreOccupied : GivenMockableBoard
    {
        protected override void Arrange()
        {
            base.Arrange();
            Mock.Get(MockableBoard)
                .Setup(board => board.AddShip(It.IsAny<IShip>()))
                .Returns(false);
            Mock.Get(MockableBoard)
                .Setup(board => board.IsVacant(It.IsAny<IEnumerable<Point>>()))
                .Returns(false);
        }

        protected override void Act()
        {
            base.Act();
            BoardService
                .AddShip(
                    MockableBoard,
                    BoardOrientation.Vertical,
                    10,
                    15,
                    10);
        }

        [Fact]
        public void Should_Not_Invoke_AddShip_Method()
        {
            Mock.Get(MockableBoard)
                .Verify(board => board.AddShip(It.IsAny<IShip>()), Times.Never);
        }
    }
}