using System;
using System.Collections.Generic;
using System.Linq;
using MontyHallProblem.Enums;
using MontyHallProblem.Interfaces;

namespace MontyHallProblem.Classes
{
    public class Game : IGame
    {
        private const string Goat = "Goat";
        private const string Car = "Car";

        private List<IDoor> _doors = new List<IDoor>
        {
            new Door { DoorState = State.Initial, Prize = Goat },
            new Door { DoorState = State.Initial, Prize = Goat },
            new Door { DoorState = State.Initial, Prize = Car }
        };

        public int GameCount { get; }
        public int WinCount { get; set; }

        public Game(int gameCount)
        {
            GameCount = gameCount;
        }

        public double WinRate => (double)WinCount / GameCount;

        public string WinRatePercentage => $"{(int)(WinRate * 100)}%";

        public IDoor UserChoosesDoor(int doorIndex)
        {
            if (doorIndex < 0 || doorIndex > 2)
            {
                throw new InvalidOperationException($"Door {doorIndex} doesn't exist.");
            }

            if (_doors[doorIndex].DoorState == State.Opened)
            {
                throw new InvalidOperationException("Door is already opened by the speaker.");
            }

            _doors[doorIndex].DoorState = State.Chosen;
            return _doors[doorIndex];
        }

        public IDoor UserChoosesDoor(Func<IDoor, bool> predicate)
        {
            var door = _doors.First(predicate);

            door.DoorState = State.Chosen;

            return door;
        }

        public int IndexOfDoor(IDoor door)
        {
            return _doors.IndexOf(door);
        }

        public IDoor SpeakerOpensDoor()
        {
            var door = _doors.First(x => x.Prize == Goat && x.DoorState != State.Chosen);

            door.DoorState = State.Opened;

            return door;
        }

        public void ResetGame()
        {
            _doors.ForEach(x => x.DoorState = State.Initial);

            _doors = _doors.OrderBy(x => new Random().Next()).ToList();
        }
    }
}