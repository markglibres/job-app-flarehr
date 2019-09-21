using System;
using System.Collections.Generic;
using System.Drawing;
using BattleShip.Domain.Constants;

namespace BattleShip.Domain.SeedWork
{
    public interface IShip
    {
        Guid Id { get; }
        IReadOnlyCollection<Coordinate> Coordinates { get; }
        ShipStatus Status { get; }
        void Hit(Point point);

    }
}