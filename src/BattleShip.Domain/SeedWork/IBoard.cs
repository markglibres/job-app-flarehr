using System.Collections.Generic;
using System.Drawing;

namespace BattleShip.Domain.SeedWork
{
    public interface IBoard
    {
        IReadOnlyCollection<IShip> Ships { get; }
        bool IsSunk();
        string GetShipId(Point point);
        bool AddShip(IShip ship);
        bool IsVacant(IEnumerable<Point> location);
        bool Attack(Point location);

        int TotalRows { get; }
        int TotalColumns { get; }
    }
}