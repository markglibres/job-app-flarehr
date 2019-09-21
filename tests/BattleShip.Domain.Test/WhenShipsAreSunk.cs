using AutoFixture;
using BattleShip.Domain.Constants;
using BattleShip.Domain.SeedWork;
using BattleShip.Domain.Test.SeedWork;
using Moq;
using Xunit;

namespace BattleShip.Domain.Test
{
    public class WhenShipsAreSunk : GivenBoard80X40
    {
        private bool _isSunk;

        protected override void Arrange()
        {
            base.Arrange();
            var sunkShip1 = Fixture.Create<IShip>();
            var sunkShip2 = Fixture.Create<IShip>();
            Mock.Get(sunkShip1)
                .SetupGet(s => s.Status)
                .Returns(ShipStatus.Sunk);
            Mock.Get(sunkShip2)
                .SetupGet(s => s.Status)
                .Returns(ShipStatus.Sunk);

            Board.AddShip(sunkShip1);
            Board.AddShip(sunkShip2);
        }

        protected override void Act()
        {
            base.Act();
            _isSunk = Board.IsSunk();
        }

        [Fact]
        public void Should_Return_True_If_All_Ships_Sunk()
        {
            Assert.True(_isSunk);
        }
    }
}