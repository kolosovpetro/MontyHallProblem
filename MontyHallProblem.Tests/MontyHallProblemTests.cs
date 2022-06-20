using FluentAssertions;
using MontyHallProblem.Classes;
using MontyHallProblem.Interfaces;
using Xunit;

namespace MontyHallProblem.Tests;

public class MontyHallProblemTests
{
    [Fact]
    public void MontyHallProblemTest_ChangeDoor_Success()
    {
        IGame game = new Game(1_000_000);
        var player = new Player(game);

        player.AutoPlay(shouldChangeChoice: true);

        game.WinRate.Should().BeGreaterThan(0.66d);
        game.WinRatePercentage.Should().Be("66%");
    }

    [Fact]
    public void MontyHallProblemTest_DoNotChangeDoor_Success()
    {
        IGame game = new Game(1_000_000);
        var player = new Player(game);

        player.AutoPlay(shouldChangeChoice: false);

        game.WinRate.Should().BeGreaterThan(0.33d);
        game.WinRatePercentage.Should().Be("33%");
    }
}