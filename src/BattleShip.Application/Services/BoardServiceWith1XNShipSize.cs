using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BattleShip.Application.Constants;
using BattleShip.Application.SeedWork;
using BattleShip.Domain;
using BattleShip.Domain.SeedWork;

namespace BattleShip.Application.Services
{
    public class BoardServiceWith1XnShipSize : IBoardService
    {
        public bool AddShip(
            IBoard board,
            BoardOrientation orientation,
            Point startingLocation,
            int length)
        {
            var coordinates = GetCoordinates(orientation,
                    startingLocation,
                    length)
                .ToList();

            var maxRow = coordinates.Max(c => c.Location.X);
            var maxColumn = coordinates.Max(c => c.Location.Y);

            if (maxRow >= board.TotalRows || maxColumn >= board.TotalColumns) return false;

            if (!board.IsVacant(coordinates.Select(c => c.Location))) return false;
            
            var ship = new Ship(coordinates);
            return board.AddShip(ship);
        }

        public bool Attack(
            IBoard board,
            Point location)
        {
            return board.Attack(location);
        }

        public bool IsSunk(IBoard board)
        {
            return board.IsSunk();
        }

        private static IEnumerable<Coordinate> GetCoordinates(
            BoardOrientation orientation,
            Point startingLocation,
            int length)
        {
            var endRow = startingLocation.X;
            var endColumn = startingLocation.Y;

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
            for (var i = startingLocation.X; i < endRow; i++)
            {
                for (var j = startingLocation.Y; j < endColumn; j++)
                {
                    coordinates.Add(new Coordinate(i, j));
                }
            }

            return coordinates;
        }
    }
}