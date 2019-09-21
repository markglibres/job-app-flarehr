using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using BattleShip.Domain.Constants;
using BattleShip.Domain.Test.SeedWork;
using Xunit;

namespace BattleShip.Domain.Test.ShipTests
{
    public class WhenCompletelyHittingShip : GivenShip
    {
        private List<Point> _targetCoordinates;

        protected override void Arrange()
        {
            base.Arrange();
            _targetCoordinates = Coordinates.Select(c => c.Location).ToList();
        }

        protected override void Act()
        {
            base.Act();
            _targetCoordinates.ForEach(location =>
            {
                Ship.Hit(location);
            });
        }

        [Fact]
        public void Should_Have_Operational_Status()
        {
            Assert.Equal(ShipStatus.Sunk, Ship.Status);
        }

        [Fact]
        public void Should_Mark_All_Target_Coordinates_As_Hit()
        {
            Assert.All(_targetCoordinates,
                point =>
                {
                    Assert.Equal(CoordinateStatus.Hit, Ship.Coordinates.Single(c => c.Location == point).Status);
                });
        }

    }
}
