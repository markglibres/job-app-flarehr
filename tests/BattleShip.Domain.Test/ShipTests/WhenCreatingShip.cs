using System;
using BattleShip.Domain.Constants;
using BattleShip.Domain.Test.SeedWork;
using Xunit;

namespace BattleShip.Domain.Test.ShipTests
{
    public class WhenCreatingShip : GivenShip
    {
        [Fact]
        public void Should_Generate_Id()
        {
            Assert.NotEqual(Guid.Empty, Ship.Id);
        }

        [Fact]
        public void Should_Have_Operational_Status()
        {
            Assert.Equal(ShipStatus.Operational, Ship.Status);
        }

        [Fact]
        public void Should_Match_Coordinates()
        {
            Assert.Equal(Coordinates, Ship.Coordinates);
        }

        [Fact]
        public void Should_Not_Be_Null()
        {
            Assert.NotNull(Ship);
        }
    }
}