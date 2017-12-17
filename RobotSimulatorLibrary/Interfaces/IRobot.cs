using RobotSimulatorLibrary.RobotStates;

namespace RobotSimulatorLibrary.Interfaces
{
    public interface IRobot:IState,ISpeed
    {
        ITable Table { get; }
        Position.Position CurrentPosition { get;  }
        void SetCurrentPosition(Position.Position position);
        void SetCurrentState(IState state);
    }
}
