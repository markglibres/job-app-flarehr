using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BattleShip.Domain.Constants;
using BattleShip.Domain.SeedWork;

namespace BattleShip.Domain
{
    public class Board : IBoard
    {
        private readonly string[,] _area;
        private readonly List<IShip> _ships;

        public IReadOnlyCollection<IShip> Ships
            => _ships.AsReadOnly();

        public Board(int rows, int columns)
        {
            _area = new string[rows, columns];
            _ships = new List<IShip>();
        }

        public bool IsSunk()
        {
            return _ships.Any() 
                   && _ships.All(ship => ship.Status != ShipStatus.Operational);
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

        public bool Attack(Point location)
        {
            var shipId = GetShipId(location);
            if (string.IsNullOrWhiteSpace(shipId)) return false;

            var ship = _ships.Single(s => s.Id.ToString() == shipId);
            ship.Hit(location);

            return true;
        }

        private void AddShip(string shipId, IEnumerable<Point> location)
        {
            location
                .ToList()
                .ForEach(point => { _area[point.X, point.Y] = shipId; });
        }
    }
}