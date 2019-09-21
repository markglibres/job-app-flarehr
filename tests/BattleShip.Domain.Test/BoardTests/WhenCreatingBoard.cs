using System.Drawing;
using BattleShip.Domain.Test.SeedWork;
using Xunit;

namespace BattleShip.Domain.Test.BoardTests
{
    public class WhenCreatingBoard : GivenBoard80X40
    {
        [Fact]
        public void Should_Create_Board_With_Empty_Slots()
        {
            for (var row = 0; row < TotalBoardRows; row++)
            {
                for (var column = 0; column < TotalBoardColumns; column++)
                {
                    Assert.True(string.IsNullOrWhiteSpace(Board.GetShipId(new Point(row, column))));
                }
            }
        }

        [Fact]
        public void Should_Contain_No_Ship()
        {
            Assert.Equal(0, Board.Ships.Count);
        }
    }
}