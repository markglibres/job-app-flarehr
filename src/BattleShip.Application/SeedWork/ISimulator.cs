using BattleShip.Domain.SeedWork;

namespace BattleShip.Application.SeedWork
{
    public interface ISimulator
    {
        void Simulate(IBoard board);
    }
}