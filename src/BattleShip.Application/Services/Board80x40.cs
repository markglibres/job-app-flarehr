using System.Collections.Generic;
using System.Linq;
using BattleShip.Application.Constants;
using BattleShip.Application.SeedWork;
using BattleShip.Domain;
using BattleShip.Domain.SeedWork;

namespace BattleShip.Application.Services
{
    public class Board80X40 : IBoardService
    {
        public IBoard CreateBoard()
        {
            var battleGround = new Board(80, 40);
            return battleGround;
        }

        public bool AddShip(
            IBoard board,
            BoardOrientation orientation,
            int row,
            int column,
            int length)
        {
            var coordinates = GetCoordinates(orientation,
                    row,
                    column,
                    length)
                .ToList();

            if (!board.IsVacant(coordinates.Select(c => c.Location)))
            {
                return false;
            }

            var ship = new Ship(coordinates);
            return board.AddShip(ship);
        }

        public bool Attack(
            IBoard board,
            int xCoordinate,
            int yCoordinate)
        {
            return false;
        }

        public bool IsSunk(IBoard board)
        {
            return board.IsSunk();
        }

        private static IEnumerable<Coordinate> GetCoordinates(
            BoardOrientation orientation,
            int row,
            int column,
            int length)
        {
            var endRow = row;
            var endColumn = column;

            if (orientation == BoardOrientation.Vertical)
            {
                endRow += length;
                endColumn++;
            }
            else
            {
                endRow++;
                endColumn += length;
            }

            var coordinates = new List<Coordinate>();
            for (var i = row; i < endRow; i++)
            {
                for (var j = column; j < endColumn; j++)
                {
                    coordinates.Add(new Coordinate(i, j));
                }
            }

            return coordinates;
        }
    }
}