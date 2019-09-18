using BattleShip.Domain.SeedWork;
using BoardOrientation = BattleShip.Application.Constants.BoardOrientation;

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