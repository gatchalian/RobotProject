using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Calculators.Visitors.Location
{
    public class LocationCalculator:BaseBound
    {

        public LocationCalculator(ILocationCalculator locationCalculator) : base(locationCalculator)
        {
        }

        public override (Position.Location location, bool found) GetLocation(Position.Position position, int lateralSpeed)
        {
            return LocationCalculator.GetLocation(position, lateralSpeed);
        }
    }
}
