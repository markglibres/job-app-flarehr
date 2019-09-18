using System;

namespace BattleShip.Domain.SeedWork
{
    public interface IBoard
    {
        int Rows { get; }
        int Columns { get; }

        string GetShipId(int row, int column);
    }
}