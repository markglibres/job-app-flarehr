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
            int row,
            int column,
            int length);

        bool Attack(
            IBoard board,
            int xCoordinate,
            int yCoordinate);

        bool IsSunk(IBoard board);
    }
}