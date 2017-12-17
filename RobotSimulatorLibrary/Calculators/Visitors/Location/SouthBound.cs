using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Calculators.Visitors.Location
{
    public class SouthBound:BaseBound
    {

        public SouthBound(ILocationCalculator locationCalculator) : base(locationCalculator)
        {
        }

        public override (Position.Location location, bool found) GetLocation(Position.Position position, int lateralSpeed)
        {
            return position.Direction == Direction.South 
                ? (new Position.Location(position.Location.X, position.Location.Y - lateralSpeed), true) 
                : LocationCalculator.GetLocation(position, lateralSpeed);
        }
    }
}
