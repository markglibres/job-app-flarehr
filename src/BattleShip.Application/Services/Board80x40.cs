﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BattleShip.Application.Constants;
using BattleShip.Application.SeedWork;
using BattleShip.Domain;
using BattleShip.Domain.SeedWork;

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
            Point startingLocation,
            int length)
        {
            var coordinates = GetCoordinates(orientation,
                    startingLocation,
                    length)
                .ToList();

            if (!board.IsVacant(coordinates.Select(c => c.Location)))
            {
                return false;
            }

            var ship = new Ship(coordinates);
            return board.AddShip(ship);
        }

        public bool Attack(
            IBoard board,
            Point location)
        {
            return false;
        }

        public bool IsSunk(IBoard board)
        {
            return board.IsSunk();
        }

        private static IEnumerable<Coordinate> GetCoordinates(
            BoardOrientation orientation,
            Point startingLocation,
            int length)
        {
            var endRow = startingLocation.X;
            var endColumn = startingLocation.Y;

            if (orientation == BoardOrientation.Vertical)
            {
                endRow += length;
                endColumn++;
            }
            else
            {
                endRow++;
                endColumn += length;
            }

            var coordinates = new List<Coordinate>();
            for (var i = startingLocation.X; i < endRow; i++)
            {
                for (var j = startingLocation.Y; j < endColumn; j++)
                {
                    coordinates.Add(new Coordinate(i, j));
                }
            }

            return coordinates;
        }
    }
}