using MontyHallProblem.Classes;

namespace MontyHallProblem.Console
{
    public static class Program
    {
        private static void Main()
        {
            var game = new Game(10);

            for (var i = 0; i < game.GameCount; i++)
            {
                System.Console.WriteLine("You have three doors, type number you choose (0,1,2): ");
                var number = int.Parse(System.Console.ReadLine() ?? "0");
                System.Console.WriteLine($"You have chosen: {number}");
                game.SpeakerOpensDoor();
                System.Console.WriteLine($"Would you like to change you choose {number}? " +
                                         "\n If not: type same number");
                number = int.Parse(System.Console.ReadLine() ?? "0");
                System.Console.WriteLine($"You have chosen: {number}");
                var userDoor = game.ChooseDoor(number);

                if (userDoor.Prise == "Car") 
                    game.WinCount++;
                
                game.ResetGame();
            }

            System.Console.WriteLine($"You have played {game.GameCount}, " +
                                     $"won: {game.WinCount}, " +
                                     $"win rate: {game.WinRate}");
        }
    }
}