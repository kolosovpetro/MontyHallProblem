using System;
using MontyHallProblem.Enums;

namespace MontyHallProblem.Interfaces;

public interface IGame
{
    int GameCount { get; }
        
    int WinCount { get; set; }

    double WinRate { get; }
        
    string WinRatePercentage { get; }

    IDoor UserChoosesDoor(int doorIndex);
        
    IDoor UserChoosesDoor(DoorState doorState);
        
    int IndexOfDoor(IDoor door);
        
    IDoor SpeakerOpensDoor();
        
    void ResetGame();
}