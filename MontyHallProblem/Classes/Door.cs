using MontyHallProblem.Enums;
using MontyHallProblem.Interfaces;

namespace MontyHallProblem.Classes
{
    public class Door : IDoor
    {
        public DoorState DoorState { get; set; }
        public string Prize { get; set; }
    }
}