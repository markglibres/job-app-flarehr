using System;
using System.Collections.Generic;
using System.Drawing;
using BattleShip.Domain.Test.SeedWork;
using Xunit;

namespace BattleShip.Domain.Test.BoardTests
{
    public class WhenGettingShipOutsideBoundary : GivenBoard80X40
    {
        private List<Point> _outsideBoundaries;

        protected override void Arrange()
        {
            base.Arrange();
            _outsideBoundaries = new List<Point>
            {
                new Point(93, 45),
                new Point(93, 46),
                new Point(93, 47),
                new Point(93, 48)
            };
        }


        [Fact]
        public void Should_Throw_Exception()
        {
            Assert.All(_outsideBoundaries,
                location => { Assert.Throws<IndexOutOfRangeException>(() => Board.GetShipId(location)); });
        }
    }
}