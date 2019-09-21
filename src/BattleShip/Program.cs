using System;
using BattleShip.Application.SeedWork;
using BattleShip.Domain.SeedWork;
using Microsoft.Extensions.DependencyInjection;

namespace BattleShip
{
    public class Program
    {
        public static IServiceProvider ServiceProvider;

        private static void Main(string[] args)
        {
            Configure();

            var board = ServiceProvider.GetService<IBoard>();
            var simulator = ServiceProvider.GetService<ISimulator>();

            simulator.Simulate(board);
        }

        private static void Configure()
        {
            ServiceProvider = DependencyInjection.ServiceProvider
                .ConfigureServices()
                .BuildServiceProvider();
        }
    }
}