using AutoFixture;

namespace BattleShip.Domain.Test.SeedWork
{
    public abstract class GivenBoard80X40 : TestSpec
    {
        protected int TotalBoardColumns;
        protected int TotalBoardRows;
        protected Board Board;
      
        protected override void Arrange()
        {
            TotalBoardRows = 80;
            TotalBoardColumns = 40;
            Fixture.Register(() => new Board(TotalBoardRows, TotalBoardColumns));
            Board = Fixture.Create<Board>();
        }

        protected override void Act()
        {
            
        }
    }
}