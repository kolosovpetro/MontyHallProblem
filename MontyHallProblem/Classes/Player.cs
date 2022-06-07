using System;
using MontyHallProblem.Enums;
using MontyHallProblem.Interfaces;

namespace MontyHallProblem.Classes
{
    public class Player : IPlayer
    {
        private IGame Game { get; }
        private readonly Random _random;

        public Player(IGame game)
        {
            Game = game;
            _random = new Random();
        }

        public void ManualPlay()
        {
            Game.WinCount = 0;
            for (var i = 0; i < Game.GameCount; i++)
            {
                Console.WriteLine($"Games played: {i} out of {Game.GameCount}. Wins: {Game.WinCount}");
                Console.WriteLine("You have three doors, type number you choose (0,1,2): ");
                var number = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"You have chosen: {number}");
                Game.UserChoosesDoor(number);
                var speakerOpensDoor = Game.SpeakerOpensDoor();
                Console.WriteLine($"Speaker opens door number {Game.IndexOfDoor(speakerOpensDoor)} " +
                                  "and there is bike!");
                Console.WriteLine($"Would you like to change you choose {number}?");
                Console.WriteLine("If not, type same number.");
                number = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"You have chosen: {number}");
                var userDoor = Game.UserChoosesDoor(number);

                if (userDoor.Prize == "Car")
                {
                    Game.WinCount++;
                    Console.WriteLine($"Congrats, you won a car. Door {number} is correct.");
                }
                else
                {
                    Console.WriteLine($"Unfortunately, there is a bike behind door {number}");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                Console.Clear();

                Game.ResetGame();
            }

            Console.WriteLine($"Session is finished. You have played {Game.GameCount} games " +
                              $" wins: {Game.WinCount}." +
                              $"\nWin rate {Game.WinRate}.");
        }

        public void AutoPlay(bool shouldChangeChoice)
        {
            Game.WinCount = 0;

            for (var i = 0; i < Game.GameCount; i++)
            {
                var initialChoose = _random.Next(0, 3);

                Game.UserChoosesDoor(initialChoose);
                Game.SpeakerOpensDoor();

                var chosenDoor = shouldChangeChoice
                    ? Game.UserChoosesDoor(DoorState.Initial)
                    : Game.UserChoosesDoor(DoorState.Chosen);

                if (chosenDoor.Prize == Classes.Game.Car)
                {
                    Game.WinCount++;
                }

                Game.ResetGame();
            }

            var strategyName = shouldChangeChoice
                ? "To change the initial choose upon request"
                : "Not to change the initial choose upon request";

            Console.WriteLine($"Session is finished. \n" +
                              $"Strategy: {strategyName} \n" +
                              $"You have played {Game.GameCount} games " +
                              $"wins: {Game.WinCount}." +
                              $"\nWin rate {Game.WinRate} or {Game.WinRatePercentage}. \n");
        }
    }
}