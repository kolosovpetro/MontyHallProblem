using System;
using MontyHallProblem.Enums;
using MontyHallProblem.Interfaces;

namespace MontyHallProblem.Classes
{
    public class Player : IPlayer
    {
        private readonly Game _game;
        private readonly Random _random;

        public Player(Game game)
        {
            _game = game;
            _random = new Random();
        }

        public void ManualPlay()
        {
            _game.WinCount = 0;
            for (var i = 0; i < _game.GameCount; i++)
            {
                Console.WriteLine($"Games played: {i} out of {_game.GameCount}. Wins: {_game.WinCount}");
                Console.WriteLine("You have three doors, type number you choose (0,1,2): ");
                var number = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"You have chosen: {number}");
                _game.UserChoosesDoor(number);
                var speakerOpensDoor = _game.SpeakerOpensDoor();
                Console.WriteLine($"Speaker opens door number {_game.IndexOfDoor(speakerOpensDoor)} " +
                                  "and there is bike!");
                Console.WriteLine($"Would you like to change you choose {number}?");
                Console.WriteLine("If not, type same number.");
                number = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"You have chosen: {number}");
                var userDoor = _game.UserChoosesDoor(number);

                if (userDoor.Prize == "Car")
                {
                    _game.WinCount++;
                    Console.WriteLine($"Congrats, you won a car. Door {number} is correct.");
                }
                else
                {
                    Console.WriteLine($"Unfortunately, there is a bike behind door {number}");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                _game.ResetGame();
            }

            Console.WriteLine($"Session is finished. You have played {_game.GameCount} games " +
                                     $" wins: {_game.WinCount}." +
                                     $"\nWin rate {(double) _game.WinCount / _game.GameCount}.");
        }

        public void AutoPlay()
        {
            _game.WinCount = 0;
            for (var i = 0; i < _game.GameCount; i++)
            {
                var initialChoose = _random.Next(0, 3);
                _game.UserChoosesDoor(initialChoose);
                _game.SpeakerOpensDoor();
                var chosenDoor = _game.UserChoosesDoor(x => x.DoorState == State.Stateless);
                if (chosenDoor.Prize == "Car")
                {
                    _game.WinCount++;
                }
                _game.ResetGame();
            }
            
            Console.WriteLine($"Session is finished. You have played {_game.GameCount} games " +
                              $" wins: {_game.WinCount}." +
                              $"\nWin rate {(double) _game.WinCount / _game.GameCount}.");
        }
    }
}