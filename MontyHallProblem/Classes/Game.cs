using System;
using System.Collections.Generic;
using System.Linq;
using MontyHallProblem.Enums;
using MontyHallProblem.Interfaces;

namespace MontyHallProblem.Classes
{
    public class Game : IGame
    {
        private List<IDoor> _doors = new List<IDoor>
        {
            new Door {DoorState = State.Stateless, Prize = "Bike"},
            new Door {DoorState = State.Stateless, Prize = "Bike"},
            new Door {DoorState = State.Stateless, Prize = "Car"}
        };

        public int GameCount { get; }
        public int WinCount { get; set; }

        public Game(int gameCount)
        {
            GameCount = gameCount;
        }

        public IDoor UserChoosesDoor(int doorIndex)
        {
            if (doorIndex < 0 || doorIndex > 2)
                throw new InvalidOperationException($"Door {doorIndex} doesn't exist.");

            if (_doors[doorIndex].DoorState == State.Opened)
                throw new InvalidOperationException("Door is already opened by speaker.");

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
            var door = _doors.First(x => x.Prize == "Bike" && x.DoorState != State.Chosen);
            door.DoorState = State.Opened;
            return door;
        }

        public void ResetGame()
        {
            _doors.ForEach(x => x.DoorState = State.Stateless);
            _doors = _doors.OrderBy(x => new Random().Next()).ToList();
        }
    }
}