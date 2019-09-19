using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using BattleShip.Domain.Constants;
using BattleShip.Domain.SeedWork;

namespace BattleShip.Domain
{
    public class Coordinate : ICoordinate
    {
        public Point Location { get; }
        public CoordinateStatus Status { get; private set; }

        public Coordinate(int row, int column)
        {
            Location = new Point(row, column);
            Status = CoordinateStatus.Active;
        }

        public void Hit()
        {
            Status = CoordinateStatus.Hit;
        }
    }
}
