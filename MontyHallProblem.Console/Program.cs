using MontyHallProblem.Classes;

namespace MontyHallProblem.Console
{
    public static class Program
    {
        private static void Main()
        {
            var player = new Player(new Game(1_000_000));
            player.AutoPlay();
        }
    }
}