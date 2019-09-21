using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using BattleShip.Application.Constants;
using BattleShip.Application.SeedWork;
using BattleShip.Domain.Constants;
using BattleShip.Domain.SeedWork;

namespace BattleShip.Application.Simulators
{
    public class SimpleSimulator : ISimulator
    {
        private readonly IBoardService _boardService;

        public SimpleSimulator(IBoardService boardService)
        {
            _boardService = boardService;
        }

        public void Simulate(IBoard board)
        {
            AddRandomShipsToBoard(_boardService, board);
            var attackedLocations = new List<Point>();
            var successfulAttackedLocations = new List<Point>();

            do
            {
                var locationToAttack = GetRandomCoordinates(board);
                if (attackedLocations.Contains(locationToAttack))
                {
                    continue;
                }

                var isHit = _boardService.Attack(board, locationToAttack);
                attackedLocations.Add(locationToAttack);

                if (isHit)
                {
                    successfulAttackedLocations.Add(locationToAttack);
                }

                Console.Clear();

                DisplayAttackSummary(board,
                    locationToAttack,
                    isHit,
                    attackedLocations,
                    successfulAttackedLocations);

                Console.WriteLine();

                DisplayBoardSummary(board);

                Thread.Sleep(100);
            } while (!_boardService.IsSunk(board));

            Console.WriteLine();
            Console.WriteLine("All your base are belong to us!");
            Console.WriteLine();
        }

        private static void DisplayAttackSummary(
            IBoard board,
            Point locationToAttack,
            bool isHit,
            List<Point> attackedLocations,
            List<Point> successfulAttackedLocations)
        {
            Console.WriteLine($"Attacking [{locationToAttack.ToString()}] => {(isHit ? "Hit!" : "Miss!")}");
            Console.WriteLine();
            Console.WriteLine($"Failed attacks: {attackedLocations.Count - successfulAttackedLocations.Count}");
            Console.WriteLine($"Successful attacks: {successfulAttackedLocations.Count}");
            Console.WriteLine($"Remaining attacks: {board.TotalRows * board.TotalColumns - attackedLocations.Count}");
        }

        private static void DisplayBoardSummary(IBoard board)
        {
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
        }

        private static void AddRandomShipsToBoard(
            IBoardService boardService,
            IBoard board)
        {
            var shipsToAdd = board.TotalRows / 3;

            while (board.Ships.Count < shipsToAdd)
            {
                var orientation = GetRandomBoardOrientation();
                var coordinates = GetRandomCoordinates(board);
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

        private static Point GetRandomCoordinates(IBoard board)
        {
            var random = new Random();
            var maxRows = board.TotalRows;
            var maxColumns = board.TotalColumns;
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