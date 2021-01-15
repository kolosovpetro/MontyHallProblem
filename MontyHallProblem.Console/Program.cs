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
                System.Console.WriteLine($"Games played: {i} out of {game.GameCount}. Wins: {game.WinCount}");
                System.Console.WriteLine("You have three doors, type number you choose (0,1,2): ");
                var number = int.Parse(System.Console.ReadLine()!);
                System.Console.WriteLine($"You have chosen: {number}");
                game.UserChoosesDoor(number);
                game.SpeakerOpensDoor();
                System.Console.WriteLine($"Would you like to change you choose {number}?");
                System.Console.WriteLine("If not, type same number.");
                number = int.Parse(System.Console.ReadLine()!);
                System.Console.WriteLine($"You have chosen: {number}");
                var userDoor = game.UserChoosesDoor(number);

                if (userDoor.Prize == "Car")
                {
                    game.WinCount++;
                    System.Console.WriteLine($"Congrats, you won a car. Door {number} is correct.");
                }
                else
                {
                    System.Console.WriteLine($"Unfortunately, there is a bike behind door {number}");
                }
                
                System.Console.WriteLine("Press any key to continue...");
                System.Console.ReadKey();
                System.Console.Clear();
                game.ResetGame();
            }
        }
    }
}