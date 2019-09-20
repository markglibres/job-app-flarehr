using System.Collections;
using System.Collections.Generic;

namespace BattleShip.Domain.Test.Data
{
    public class BoardIsNotVacantTestData : IEnumerable<object[]>
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
                    new Coordinate(3,5),
                    new Coordinate(4, 5),
                    new Coordinate(5, 5),
                    new Coordinate(6, 5),
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
                    new Coordinate(6,5),
                    new Coordinate(7, 5),
                    new Coordinate(8, 5),
                    new Coordinate(9, 5),
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
                    new Coordinate(5,4),
                    new Coordinate(5, 5),
                    new Coordinate(5, 6),
                    new Coordinate(5, 7),
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
