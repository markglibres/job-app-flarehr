using AutoFixture;
using AutoFixture.AutoMoq;

namespace BattleShip.Application.Test.SeedWork
{
    public abstract class TestSpec
    {
        protected readonly IFixture Fixture;

        protected TestSpec()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            Arrange();
            Act();
        }

        protected abstract void Arrange();
        protected abstract void Act();
    }
}