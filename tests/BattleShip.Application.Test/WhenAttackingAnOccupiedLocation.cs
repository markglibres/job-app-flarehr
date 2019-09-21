using System.Drawing;
using BattleShip.Application.Test.SeedWork;
using Moq;
using Xunit;

namespace BattleShip.Application.Test
{
    public class WhenAttackingAnOccupiedLocation : GivenMockableBoard
    {
        private Point _locationToAttack;

        protected override void Arrange()
        {
            base.Arrange();
            _locationToAttack = new Point(3, 5);
        }

        protected override void Act()
        {
            base.Act();
            BoardService.Attack(MockableBoard, _locationToAttack);
        }

        [Fact]
        public void Should_Invoke_Attack_Method()
        {
            Mock.Get(MockableBoard)
                .Verify(b => b.Attack(_locationToAttack), Times.Once);
        }
    }
}