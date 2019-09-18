using BattleShip.Domain.Constants;
using BattleShip.Domain.SeedWork;

namespace BattleShip.Application.SeedWork
{
    public interface IBoardService
    {
        IBoard CreateBoard();

        bool AddShip(
            IBoard board,
            BoardOrientation orientation,
            int startingPoint,
            int length);

        bool Attack(
            IBoard board,
            int xCoordinate,
            int yCoordinate);

        bool IsSunk(IBoard board);
    }
}