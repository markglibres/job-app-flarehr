using BattleShip.Application.SeedWork;
using BattleShip.Domain;
using BattleShip.Domain.SeedWork;
using BoardOrientation = BattleShip.Application.Constants.BoardOrientation;

namespace BattleShip.Application.Services
{
    public class Board80X40 : IBoardService
    {
        public IBoard CreateBoard()
        {
            var battleGround = new Board(80, 40);
            return battleGround;
        }

        public bool AddShip(
            IBoard board, 
            BoardOrientation orientation, 
            int startingPoint, 
            int length)
        {
            return true;
        }

        public bool Attack(
            IBoard board,
            int xCoordinate,
            int yCoordinate)
        {
            return false;
        }

        public bool IsSunk(IBoard board)
        {
            return false;
        }
    }

}