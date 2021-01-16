using System;

namespace MontyHallProblem.Interfaces
{
    public interface IGame
    {
        int GameCount { get; }
        int WinCount { get; set; }
        IDoor UserChoosesDoor(int doorIndex);
        IDoor UserChoosesDoor(Func<IDoor, bool> predicate);
        int IndexOfDoor(IDoor door);
        IDoor SpeakerOpensDoor();
        void ResetGame();
    }
}