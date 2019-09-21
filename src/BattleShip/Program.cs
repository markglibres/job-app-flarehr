using System;
using BattleShip.Application.SeedWork;
using BattleShip.Domain.SeedWork;
using BattleShip.Simulators;
using Microsoft.Extensions.DependencyInjection;

namespace BattleShip
{
    public class Program
    {
        public static IServiceProvider ServiceProvider;

        private static void Main(string[] args)
        {
            Configure();
            var boardService = ServiceProvider.GetService<IBoardService>();
            var board = ServiceProvider.GetService<IBoard>();

            SimpleSimulator.Simulate(boardService, board);
        }

        private static void Configure()
        {
            ServiceProvider = DependencyInjection.ServiceProvider
                .ConfigureServices()
                .BuildServiceProvider();
        }
    }
}