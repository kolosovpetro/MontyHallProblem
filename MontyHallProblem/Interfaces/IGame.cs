namespace MontyHallProblem.Interfaces
{
    public interface IGame
    {
        int GameCount { get; }
        int WinCount { get; set; }
        double WinRate { get; }
        IDoor ChooseDoor(int doorIndex);
        IDoor SpeakerOpensDoor();
        void ResetGame();
    }
}