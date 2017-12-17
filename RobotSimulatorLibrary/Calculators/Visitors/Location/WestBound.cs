using System;
using System.Collections.Generic;
using System.Text;
using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Calculators.Visitors.Location
{
    public class WestBound:BaseBound
    {
        public WestBound(ILocationCalculator locationCalculator) : base(locationCalculator)
        {
        }

        public override (Position.Location location, bool found) GetLocation(Position.Position position, int lateralSpeed)
        {
            return position.Direction == Direction.West 
                ? (new Position.Location(position.Location.X - lateralSpeed, position.Location.Y), true) 
                : (position.Location, false);
        }
    }
}
