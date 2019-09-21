using System.Collections.Generic;
using System.Drawing;
using BattleShip.Application.Constants;
using BattleShip.Application.Test.SeedWork;
using BattleShip.Domain.SeedWork;
using Moq;
using Xunit;

namespace BattleShip.Application.Test
{
    public class WhenAddingShipAndCoordinatesAreVacant : GivenFakeBoard
    {
        protected override void Arrange()
        {
            base.Arrange();
            Mock.Get(Board)
                .Setup(board => board.AddShip(It.IsAny<IShip>()))
                .Returns(true);
            Mock.Get(Board)
                .Setup(board => board.IsVacant(It.IsAny<IEnumerable<Point>>()))
                .Returns(true);
        }

        protected override void Act()
        {
            base.Act();
            BoardService
                .AddShip(
                    Board,
                    BoardOrientation.Vertical,
                    10,
                    15,
                    10);
        }

        [Fact]
        public void Should_Invoke_AddShip_Method_Only_Once()
        {
            Mock.Get(Board)
                .Verify(board => board.AddShip(It.IsAny<IShip>()), Times.Once);
        }
    }
}