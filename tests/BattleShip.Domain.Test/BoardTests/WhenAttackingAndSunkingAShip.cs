using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AutoFixture;
using BattleShip.Domain.Constants;
using BattleShip.Domain.SeedWork;
using BattleShip.Domain.Test.SeedWork;
using Moq;
using Xunit;

namespace BattleShip.Domain.Test.BoardTests
{
    public class WhenAttackingAndSunkingAShip : GivenBoard80X40
    {
        private IShip _ship;
        private List<Point> _locationsToAttack;
        private List<bool> _hitResults;

        protected override void Arrange()
        {
            base.Arrange();
            _hitResults = new List<bool>();
            _locationsToAttack = new List<Point>
            {
                new Point(3, 5),
                new Point(3, 6),
                new Point(3, 7),
                new Point(3, 8)
            };

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
            Mock.Get(_ship)
                .Setup(s => s.Hit(It.IsAny<Point>()))
                .Callback((Point location) =>
                {
                    _hitResults.Add(true);
                });
            Board.AddShip(_ship);
        }

        protected override void Act()
        {
            base.Act();
            _locationsToAttack.ForEach(location => { Board.Attack(location); });

            var shipStatus = _hitResults.Count == _ship.Coordinates.Count 
                ? ShipStatus.Sunk
                : ShipStatus.Operational;

            Mock.Get(_ship)
                .SetupGet(s => s.Status)
                .Returns(shipStatus);
        }

        [Fact]
        public void Should_Hit_The_Ship_On_All_Locations()
        {
            Mock.Get(_ship)
                .Verify(s => s.Hit(It.IsAny<Point>()), Times.Exactly(_locationsToAttack.Count));
            Assert.All(_ship.Coordinates.Select(s => s.Location),
                point => { Assert.Contains(point, _locationsToAttack); });
        }

    }
}