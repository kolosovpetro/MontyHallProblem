using MontyHallProblem.Enums;
using MontyHallProblem.Interfaces;

namespace MontyHallProblem.Classes
{
    public class Door : IDoor
    {
        public State DoorState { get; set; }
        public string Prize { get; set; }
    }
}