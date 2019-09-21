using AutoFixture;
using BattleShip.Domain.SeedWork;
using Moq;

namespace BattleShip.Application.Test.SeedWork
{
    public abstract class GivenMockBoard : GivenBoardServiceWith1XnShipSize
    {
        protected IBoard MockBoard { get; set; }

        protected override void Arrange()
        {
            base.Arrange();
            MockBoard = Fixture.Create<IBoard>();
            Mock.Get(MockBoard)
                .SetupGet(b => b.TotalRows)
                .Returns(40);
            Mock.Get(MockBoard)
                .SetupGet(b => b.TotalColumns)
                .Returns(40);
        }
    }
}