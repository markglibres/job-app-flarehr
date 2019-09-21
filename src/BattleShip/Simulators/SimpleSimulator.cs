using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using BattleShip.Application.Constants;
using BattleShip.Application.SeedWork;
using BattleShip.Domain.Constants;
using BattleShip.Domain.SeedWork;

namespace BattleShip.Simulators
{
    public static class SimpleSimulator
    {
        public static void Simulate(IBoardService boardService, IBoard board)
        {
            AddRandomShipsToBoard(boardService, board);
            var successfulAttackedLocations = new List<Point>();

            do
            {
                var locationToAttack = GetRandomCoordinates();
                if (successfulAttackedLocations.Contains(locationToAttack))
                {
                    continue;
                }

                var isHit = boardService.Attack(board, locationToAttack);
                successfulAttackedLocations.Add(locationToAttack);

                Console.Clear();
                Console.WriteLine($"Attacking [{locationToAttack.ToString()}] => {(isHit ? "Hit!" : "Miss!")}");
                Console.WriteLine();
                Console.WriteLine("Ship remaining location:");
                Console.WriteLine();
                board.Ships.ToList()
                    .ForEach(ship =>
                    {
                        var remainingLocations = ship
                            .Coordinates
                            .Where(s => s.Status == CoordinateStatus.Active)
                            .Select(s => s.Location.ToString());
                        Console.WriteLine($"Ship ({ship.Status}) {ship.Id}: {string.Join(',', remainingLocations)}");
                    });
                Console.WriteLine();
                Console.WriteLine($"Total ships: {board.Ships.Count}");
                Console.WriteLine($"Sunk ships: {board.Ships.Count(s => s.Status == ShipStatus.Sunk)}");

                Thread.Sleep(100);

                if (!isHit)
                {
                    continue;
                }

                Thread.Sleep(1000);
            } while (!boardService.IsSunk(board));

            Console.WriteLine();
            Console.WriteLine("All your base are belong to us!");
            Console.WriteLine();
        }

        private static void AddRandomShipsToBoard(
            IBoardService boardService,
            IBoard board)
        {
            const int shipsToAdd = 3;

            while (board.Ships.Count < shipsToAdd)
            {
                var orientation = GetRandomBoardOrientation();
                var coordinates = GetRandomCoordinates();
                var shipSize = GetRandomShipSize();

                boardService.AddShip(board,
                    orientation,
                    coordinates,
                    shipSize);
            }
        }

        private static BoardOrientation GetRandomBoardOrientation()
        {
            var random = new Random();
            var orientation = random.Next(0, 1);

            return (BoardOrientation) orientation;
        }

        private static Point GetRandomCoordinates()
        {
            var random = new Random();
            const int maxRows = 10;
            const int maxColumns = 10;
            return new Point(random.Next(0, maxRows), random.Next(0, maxColumns));
        }

        private static int GetRandomShipSize()
        {
            var random = new Random();
            const int minSize = 3;
            const int maxSize = 6;
            return random.Next(minSize, maxSize);
        }
    }
}