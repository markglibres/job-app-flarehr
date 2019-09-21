using AutoFixture;
using BattleShip.Application.Services;

namespace BattleShip.Application.Test.SeedWork
{
    public abstract class GivenBoard80X40Service : TestSpec
    {
        protected Board80X40 BoardService { get; set; }

        protected override void Arrange()
        {
            BoardService = Fixture.Create<Board80X40>();
        }

        protected override void Act()
        {
        }
    }
}