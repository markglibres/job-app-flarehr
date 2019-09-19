using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using BattleShip.Application.Constants;

namespace BattleShip.Application.Test.Data
{
    public class BoardServiceCoordinatesTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                BoardOrientation.Vertical,
                3,
                5,
                4,
                new List<Point>
                {
                    new Point(3, 5),
                    new Point(4, 5),
                    new Point(5, 5),
                    new Point(6, 5),
                }
            };

            yield return new object[]
            {
                BoardOrientation.Horizontal,
                3,
                5,
                4,
                new List<Point>
                {
                    new Point(3, 5),
                    new Point(3, 6),
                    new Point(3, 7),
                    new Point(3, 8),
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
