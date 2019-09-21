using System.Collections.Generic;
using AutoFixture;

namespace BattleShip.Domain.Test.SeedWork
{
    public abstract class GivenShip : TestSpec
    {
        protected List<Coordinate> Coordinates { get; set; }
        protected Ship Ship { get; private set; }

        protected override void Arrange()
        {
            Coordinates = new List<Coordinate>
            {
                new Coordinate(3, 5),
                new Coordinate(3, 6),
                new Coordinate(3, 7),
                new Coordinate(3, 8)
            };
            Fixture.Register(() => new Ship(Coordinates));
            Ship = Fixture.Create<Ship>();
        }

        protected override void Act()
        {
        }
    }
}