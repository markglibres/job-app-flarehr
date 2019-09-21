using AutoFixture;
using BattleShip.Domain.Constants;
using BattleShip.Domain.SeedWork;
using BattleShip.Domain.Test.SeedWork;
using Moq;
using Xunit;

namespace BattleShip.Domain.Test
{
    public class WhenShipsAreNotSunk : GivenBoard80X40
    {
        private bool _isSunk;

        protected override void Arrange()
        {
            base.Arrange();
            var operationalShip = Fixture.Create<IShip>();
            var sunkShip = Fixture.Create<IShip>();
            Mock.Get(operationalShip)
                .SetupGet(s => s.Status)
                .Returns(ShipStatus.Operational);
            Mock.Get(sunkShip)
                .SetupGet(s => s.Status)
                .Returns(ShipStatus.Sunk);

            Board.AddShip(operationalShip);
            Board.AddShip(sunkShip);
        }

        protected override void Act()
        {
            base.Act();
            _isSunk = Board.IsSunk();
        }

        [Fact]
        public void Should_Return_False_If_Not_All_Ships_Sunk()
        {
            Assert.False(_isSunk);
        }
    }
}