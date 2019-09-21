using System;
using BattleShip.Application.SeedWork;
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

            var board = boardService.CreateBoard();

            Console.WriteLine("Hello World");
        }

        private static void Configure()
        {
            ServiceProvider = DependencyInjection.ServiceProvider
                .ConfigureServices()
                .BuildServiceProvider();
        }
    }
}