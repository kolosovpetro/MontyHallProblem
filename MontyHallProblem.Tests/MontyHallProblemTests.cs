using FluentAssertions;
using MontyHallProblem.Classes;
using MontyHallProblem.Interfaces;
using NUnit.Framework;

namespace MontyHallProblem.Tests
{
    [TestFixture]
    public class MontyHallProblemTests
    {
        [Test]
        public void MontyHallProblemTest_ChangeDoor_Success()
        {
            IGame game = new Game(1_000_000);
            var player = new Player(game);

            player.AutoPlay(shouldChangeChoice: true);

            game.WinRate.Should().BeGreaterThan(0.66d);
            game.WinRatePercentage.Should().Be("66%");
        }

        [Test]
        public void MontyHallProblemTest_DoNotChangeDoor_Success()
        {
            IGame game = new Game(1_000_000);
            var player = new Player(game);

            player.AutoPlay(shouldChangeChoice: false);

            game.WinRate.Should().BeGreaterThan(0.33d);
            game.WinRatePercentage.Should().Be("33%");
        }
    }
}