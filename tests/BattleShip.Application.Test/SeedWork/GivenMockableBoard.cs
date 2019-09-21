using AutoFixture;
using BattleShip.Domain.SeedWork;

namespace BattleShip.Application.Test.SeedWork
{
    public abstract class GivenMockableBoard : GivenBoard80X40Service
    {
        protected IBoard MockableBoard { get; set; }

        protected override void Arrange()
        {
            base.Arrange();
            MockableBoard = Fixture.Create<IBoard>();
        }
    }
}