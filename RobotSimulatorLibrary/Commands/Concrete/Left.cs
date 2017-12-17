using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Commands.Concrete
{
    public class Left:ICommand
    {
        public Position.Position Position { get; set; }
    }
}
