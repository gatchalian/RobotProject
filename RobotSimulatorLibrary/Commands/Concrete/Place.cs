using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Commands.Concrete
{
    public class Place:ICommand
    {
        public Position.Position Position { get; set; }
    }
}
