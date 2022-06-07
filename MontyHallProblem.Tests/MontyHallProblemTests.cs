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
        public void MontyHallProblemTest_Success()
        {
            IGame game = new Game(1_000_000);
            var player = new Player(game);

            player.AutoPlay();

            game.WinRate.Should().BeGreaterThan(0.66d);
            game.WinRatePercentage.Should().Be("66%");
        }
    }
}