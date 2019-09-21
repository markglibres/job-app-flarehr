using BattleShip.Application.SeedWork;
using BattleShip.Application.Services;
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

            serviceCollection.AddSingleton<IBoardService, Board10X10>();

            return serviceCollection;
        }
    }
}