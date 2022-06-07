using MontyHallProblem.Enums;

namespace MontyHallProblem.Interfaces
{
    public interface IDoor
    {
        DoorState DoorState { get; set; }
        string Prize { get; set; }
    }
}