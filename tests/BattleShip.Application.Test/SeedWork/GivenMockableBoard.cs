using AutoFixture;
using BattleShip.Domain.SeedWork;

namespace BattleShip.Application.Test.SeedWork
{
    public abstract class GivenFakeBoard : GivenBoard80X40Service
    {
        protected IBoard Board { get; set; }

        protected override void Arrange()
        {
            base.Arrange();
            Board = Fixture.Create<IBoard>();
        }
    }
}