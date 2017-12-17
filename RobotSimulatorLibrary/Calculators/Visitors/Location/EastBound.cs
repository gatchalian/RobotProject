using System;
using System.Collections.Generic;
using System.Text;
using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Calculators.Visitors.Location
{
    public class EastBound : BaseBound
    {
        public EastBound(ILocationCalculator locationCalculator) : base(locationCalculator)
        {
        }

        public override (Position.Location location, bool found) GetLocation(Position.Position position, int lateralSpeed)
        {
            return position.Direction == Direction.East 
                ? (new Position.Location(position.Location.X + lateralSpeed, position.Location.Y), true) 
                : LocationCalculator.GetLocation(position, lateralSpeed);
        }

   
    }
}
