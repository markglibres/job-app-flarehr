using System.Collections.Generic;
using System.Drawing;

namespace BattleShip.Domain.SeedWork
{
    public interface IBoard
    {
        int Rows { get; }
        int Columns { get; }

        string GetShipId(Point point);
        bool AddShip(IShip ship);
        bool IsVacant(IEnumerable<Point> location);
    }
}