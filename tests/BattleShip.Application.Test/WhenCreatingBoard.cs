using BattleShip.Application.Test.SeedWork;
using BattleShip.Domain.SeedWork;
using Xunit;

namespace BattleShip.Application.Test
{
    public class WhenCreatingBoard : GivenBoard80X40Service
    {
        private IBoard _board;

        protected override void Act()
        {
            base.Act();
            _board = BoardService.CreateBoard();
        }

        [Fact]
        public void Should_Create_Non_Null_Board()
        {
            Assert.NotNull(_board);
        }
    }
}