using System;
using System.Collections.Generic;
using System.Text;
using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Calculators.Visitors.Location
{
    public class NorthBound: BaseBound
    {
        public NorthBound(ILocationCalculator locationCalculator) : base(locationCalculator)
        {
        }
        public override (Position.Location location, bool found) GetLocation(Position.Position position, int lateralSpeed)
        {
            return position.Direction == Direction.North
                ? (new Position.Location(position.Location.X, position.Location.Y + lateralSpeed), true)
                : LocationCalculator.GetLocation(position, lateralSpeed);
        }
    }
}
