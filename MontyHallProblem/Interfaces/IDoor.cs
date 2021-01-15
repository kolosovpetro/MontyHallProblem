using MontyHallProblem.Enums;

namespace MontyHallProblem.Interfaces
{
    public interface IDoor
    {
        State DoorState { get; set; }
        string Prize { get; set; }
    }
}