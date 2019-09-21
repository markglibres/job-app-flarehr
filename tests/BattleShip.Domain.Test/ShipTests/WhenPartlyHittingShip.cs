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
    public class WhenPartlyHittingShip : GivenShip
    {
        private List<Point> _targetCoordinates;

        protected override void Arrange()
        {
            base.Arrange();
            _targetCoordinates = new List<Point>
            {
                Coordinates[0].Location,
                Coordinates[2].Location
            };
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
            Assert.Equal(ShipStatus.Operational, Ship.Status);
        }

        [Fact]
        public void Should_Mark_Target_Coordinates_As_Hit()
        {
            Assert.All(_targetCoordinates,
                point =>
                {
                    Assert.Equal(CoordinateStatus.Hit, Ship.Coordinates.Single(c => c.Location == point).Status);
                });
        }

        [Fact]
        public void Should_Not_Mark_NonTarget_Coordinates_As_Hit()
        {
            var nonTarget = Ship
                .Coordinates
                .Where(c => !_targetCoordinates.Contains(c.Location));

            Assert.NotEmpty(nonTarget);
            Assert.All(nonTarget,
                coordinate =>
                {
                    Assert.Equal(CoordinateStatus.Active, coordinate.Status);
                });
        }
    }
}
