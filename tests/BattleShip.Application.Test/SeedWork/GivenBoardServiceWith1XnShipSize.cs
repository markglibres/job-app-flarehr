using AutoFixture;
using BattleShip.Application.Services;

namespace BattleShip.Application.Test.SeedWork
{
    public abstract class GivenBoardServiceWith1XnShipSize : TestSpec
    {
        protected BoardServiceWith1XnShipSize BoardServiceWith1XnShipSize { get; set; }

        protected override void Arrange()
        {
            BoardServiceWith1XnShipSize = Fixture.Create<BoardServiceWith1XnShipSize>();
        }

        protected override void Act()
        {
        }
    }
}