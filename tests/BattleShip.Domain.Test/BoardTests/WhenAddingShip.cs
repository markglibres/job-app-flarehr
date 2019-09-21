using System.Collections.Generic;
using AutoFixture;
using BattleShip.Domain.SeedWork;
using BattleShip.Domain.Test.SeedWork;
using Moq;
using Xunit;

namespace BattleShip.Domain.Test.BoardTests
{
    public class WhenAddingShip : GivenBoard80X40
    {
        private IShip _ship;

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
        }

        protected override void Act()
        {
            base.Act();
            Board.AddShip(_ship);
        }

        [Fact]
        public void Should_Increase_Number_Of_Ships()
        {
            Assert.Equal(1, Board.Ships.Count);
        }

        [Fact]
        public void Should_Confirm_Ship_Location()
        {
            Assert.All(_ship.Coordinates,
                coordinate => { Assert.Equal(_ship.Id.ToString(), (string) Board.GetShipId(coordinate.Location)); });
        }

    }
}