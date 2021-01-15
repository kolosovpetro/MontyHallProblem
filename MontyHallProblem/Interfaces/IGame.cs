namespace MontyHallProblem.Interfaces
{
    public interface IGame
    {
        int GameCount { get; }
        int WinCount { get; set; }
        IDoor UserChoosesDoor(int doorIndex);
        IDoor SpeakerOpensDoor();
        void ResetGame();
    }
}