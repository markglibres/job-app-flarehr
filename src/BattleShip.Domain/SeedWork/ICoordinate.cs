using System.Drawing;
using BattleShip.Domain.Constants;

namespace BattleShip.Domain.SeedWork
{
    public interface ICoordinate
    {
        Point Location { get; }
        CoordinateStatus Status { get; }

        void Hit();
    }
}