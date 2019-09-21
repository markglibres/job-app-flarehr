using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using BattleShip.Domain.SeedWork;
using BattleShip.Domain.Test.SeedWork;
using Moq;
using Xunit;

namespace BattleShip.Domain.Test.BoardTests
{
    public class WhenGettingShip : GivenBoard80X40
    {
        private IShip _ship;
        private IEnumerable<string> _shipIds;

        protected override void Arrange()
        {
            base.Arrange();
            _ship = Fixture.Create<IShip>();
            Mock.Get(_ship)
                .SetupGet(s => s.Coordinates)
                .Returns(new List<Coordinate>
                {
                    new Coordinate(3, 5),
                    new Coordinate(3, 6),
                    new Coordinate(3, 7),
                    new Coordinate(3, 8)
                });
            Board.AddShip(_ship);
        }

        protected override void Act()
        {
            base.Act();
            _shipIds = _ship
                .Coordinates
                .Select<Coordinate, string>(c => Board.GetShipId(c.Location));
        }

        [Fact]
        public void Should_Only_Get_One_ShipId()
        {
            Assert.Single(_shipIds.Distinct());
        }

        [Fact]
        public void Should_Match_ShipId()
        {
            Assert.Equal(_ship.Id.ToString(), _shipIds.First());
        }

    }
}