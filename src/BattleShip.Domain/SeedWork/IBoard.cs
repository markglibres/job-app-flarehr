using System.Collections.Generic;
using System.Drawing;
using BattleShip.Domain.Constants;

namespace BattleShip.Domain.SeedWork
{
    public interface IBoard
    {
        bool IsSunk();
        string GetShipId(Point point);
        bool AddShip(IShip ship);
        bool IsVacant(IEnumerable<Point> location);
    }
}