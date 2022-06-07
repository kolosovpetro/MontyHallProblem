namespace MontyHallProblem.Interfaces
{
    public interface IPlayer
    {
        void ManualPlay();
        void AutoPlay(bool shouldChangeChoice);
    }
}