using System;
using BattleShip.Domain.SeedWork;

namespace BattleShip.Domain
{
    public class Board : IBoard
    {
        private readonly string[,] _area;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _area = new string[Rows, Columns];
        }

        public int Rows { get; }
        public int Columns { get; }
        public string GetShipId(int row, int column)
        {
            return _area[row,column];
        }
    }
}