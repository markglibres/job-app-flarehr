using BattleShip.Domain;
using BattleShip.Domain.SeedWork;

namespace BattleShip.Application.Services
{
    public class Board10X10 : BoardWith1XnShipSize
    {
        public override IBoard CreateBoard()
        {
            var battleGround = new Board(10, 10);
            return battleGround;
        }
    }
}