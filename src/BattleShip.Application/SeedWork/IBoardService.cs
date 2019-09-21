using System.Drawing;
using BattleShip.Domain.SeedWork;
using BoardOrientation = BattleShip.Application.Constants.BoardOrientation;

namespace BattleShip.Application.SeedWork
{
    public interface IBoardService
    {
        bool AddShip(
            IBoard board,
            BoardOrientation orientation,
            Point startingLocation,
            int length);

        bool Attack(
            IBoard board,
            Point location);

        bool IsSunk(IBoard board);
    }
}