using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BattleShip.Domain.Constants;
using BattleShip.Domain.SeedWork;

namespace BattleShip.Domain
{
    public class Ship : IShip
    {
        private readonly IEnumerable<Coordinate> _coordinates;

        public Ship(IEnumerable<Coordinate> coordinates)
        {
            Id = Guid.NewGuid();
            _coordinates = coordinates;
        }

        public Guid Id { get; }

        public IReadOnlyCollection<Coordinate> Coordinates 
            => _coordinates.ToList().AsReadOnly();

        public ShipStatus Status 
            => _coordinates.All(c => c.Status == CoordinateStatus.Hit)
            ? ShipStatus.Sunk
            : ShipStatus.Operational;

        public void Hit(Point point)
        {
            var coordinate = Coordinates
                .FirstOrDefault(c => c.Location == point);

            coordinate?.Hit();
        }
    }
}