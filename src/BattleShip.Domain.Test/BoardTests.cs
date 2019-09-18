using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleShip.Domain.Test
{
    public class BoardTests
    {
        private readonly Board _board;

        public BoardTests()
        {
            _board = new Board(80, 40);
        }

        [Fact]
        public void Should_Create_Board_With_Empty_Slots()
        {
            for (var row = 0; row < _board.Rows; row++)
            {
                for (var column = 0; column < _board.Columns; column++)
                {
                    Assert.True(string.IsNullOrWhiteSpace(_board.GetShipId(row, column)));
                }
            }
        }
    }
}
