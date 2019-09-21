using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using BattleShip.Domain.SeedWork;
using BattleShip.Domain.Test.SeedWork;
using Moq;
using Xunit;

namespace BattleShip.Domain.Test.BoardTests
{
    public class WhenCheckingOccupiedCoordinates : GivenBoard80X40
    {
        private IShip _ship;
        private bool _isVacant;

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
            _isVacant = Board.IsVacant(_ship.Coordinates.Select(c => c.Location));
        }

        [Fact]
        public void IsVacant_Should_Return_False()
        {
            Assert.False(_isVacant);
        }

        
    }
}