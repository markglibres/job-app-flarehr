using System.Collections.Generic;
using System.Drawing;
using BattleShip.Application.Constants;
using BattleShip.Application.Test.SeedWork;
using BattleShip.Domain.SeedWork;
using Moq;
using Xunit;

namespace BattleShip.Application.Test
{
    public class WhenTryingToAddAShipAndCoordinatesAreVacant : GivenFakeBoard
    {
        private List<Point> _location;

        protected override void Arrange()
        {
            base.Arrange();
            _location = new List<Point>();
            Mock.Get(Board)
                .Setup(board => board.IsVacant(It.IsAny<IEnumerable<Point>>()))
                .Callback((IEnumerable<Point> coordinates) => { _location.AddRange(coordinates); })
                .Returns(true);
            Mock.Get(Board)
                .Setup(board => board.AddShip(It.IsAny<IShip>()))
                .Returns(true);
        }

        protected override void Act()
        {
            base.Act();
            BoardService
                .AddShip(
                    Board,
                    BoardOrientation.Vertical,
                    3,
                    5,
                    4);
        }


        [Fact]
        public void Should_Calculate_Correct_Coordinates()
        {
            var expectedCoordinates = new List<Point>
            {
                new Point(3, 5),
                new Point(4, 5),
                new Point(5, 5),
                new Point(6, 5)
            };

            Assert.All(expectedCoordinates,
                point => { Assert.Contains(point, _location); });
        }
    }
}