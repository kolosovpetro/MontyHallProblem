using MontyHallProblem.Classes;

namespace MontyHallProblem.Console
{
    public static class Program
    {
        private static void Main()
        {
            var player = new Player(new Game(10));
            //// use autoplay in order to verify that chance is 66, set in constructor 1000000 games
            // player.AutoPlay();
            player.ManualPlay();
        }
    }
}