namespace RobotSimulatorLibrary.Interfaces
{
    public interface IState
    {
        Position.Position GetReport();
        void Execute(ICommand command);
    }
}
