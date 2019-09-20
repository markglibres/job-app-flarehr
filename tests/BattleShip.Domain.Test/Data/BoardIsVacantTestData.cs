using System.Collections;
using System.Collections.Generic;

namespace BattleShip.Domain.Test.Data
{
    public class BoardIsVacantTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<Coordinate>
                {
                    new Coordinate(3,5),
                    new Coordinate(4, 5),
                    new Coordinate(5, 5),
                    new Coordinate(6, 5),
                },
                new List<Coordinate>
                {
                    new Coordinate(3,6),
                    new Coordinate(3,7),
                    new Coordinate(3,8),
                    new Coordinate(3,9),
                }
            };
            yield return new object[]
            {
                new List<Coordinate>
                {
                    new Coordinate(3,5),
                    new Coordinate(4, 5),
                    new Coordinate(5, 5),
                    new Coordinate(6, 5),
                },
                new List<Coordinate>
                {
                    new Coordinate(2,4),
                    new Coordinate(2,5),
                    new Coordinate(2,6),
                    new Coordinate(2,7),
                }
            };
            yield return new object[]
            {
                new List<Coordinate>
                {
                    new Coordinate(3,5),
                    new Coordinate(4, 5),
                    new Coordinate(5, 5),
                    new Coordinate(6, 5),
                },
                new List<Coordinate>
                {
                    new Coordinate(7,3),
                    new Coordinate(7,4),
                    new Coordinate(7,5),
                    new Coordinate(7,6),
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
