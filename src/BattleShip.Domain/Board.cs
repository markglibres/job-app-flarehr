using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BattleShip.Domain.SeedWork;

namespace BattleShip.Domain
{
    public class Board : IBoard
    {
        private readonly string[,] _area;
        private readonly List<IShip> _ships;
        public int Rows { get; }
        public int Columns { get; }


        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _area = new string[Rows, Columns];
            _ships = new List<IShip>();
        }

        
        public string GetShipId(Point point)
        {
            return _area[point.X, point.Y];
        }

        public bool AddShip(IShip ship)
        {
            var location = ship
                .Coordinates
                .Select(c => c.Location)
                .ToList();

            if (!IsVacant(location))
            {
                return false;
            }

            _ships.Add(ship);
            AddShip(ship.Id.ToString(), location);

            return true;
        }

        public bool IsVacant(IEnumerable<Point> location)
        {
            return location
                .Select(point => GetShipId(new Point(point.X, point.Y)))
                .All(string.IsNullOrWhiteSpace);
        }

        private void AddShip(string shipId, IEnumerable<Point> location)
        {
            location
                .ToList()
                .ForEach(point => { _area[point.X, point.Y] = shipId; });
        }
    }
}