using MontyHallProblem.Classes;
using MontyHallProblem.Interfaces;

namespace MontyHallProblem.Console
{
    public static class Program
    {
        private static void Main()
        {
            IGame game = new Game(1_000_000);
            var player = new Player(game);
            player.AutoPlay(shouldChangeChoice: true);

            game.ResetGame();

            player.AutoPlay(shouldChangeChoice: false);
        }
    }
}