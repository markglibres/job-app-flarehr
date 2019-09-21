using BattleShip.Application.SeedWork;
using BattleShip.Application.Services;
using BattleShip.Domain;
using BattleShip.Domain.SeedWork;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BattleShip.DependencyInjection
{
    public static class ServiceProvider
    {
        public static IServiceCollection ConfigureServices()
        {
            //setup our DI
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(configure => configure.AddConsole());

            serviceCollection.AddSingleton<IBoardService, BoardServiceWith1XnShipSize>();
            serviceCollection.AddTransient<IBoard>(c => new Board(10, 10));

            return serviceCollection;
        }
    }
}