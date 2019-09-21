using System;
using System.Collections.Generic;
using AutoFixture;
using BattleShip.Domain.SeedWork;
using BattleShip.Domain.Test.SeedWork;
using Moq;
using Xunit;

namespace BattleShip.Domain.Test
{
    public class WhenAddingShipOutsideTheBoundary : GivenBoard80X40
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
                    new Coordinate(93, 45),
                    new Coordinate(93, 46),
                    new Coordinate(93, 47),
                    new Coordinate(93, 48)
                });
        }


        [Fact]
        public void Should_Throw_Exception()
        {
            Assert.Throws<IndexOutOfRangeException>(() => Board.AddShip(_ship));
        }

    }
}