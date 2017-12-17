using System;
using System.Collections.Generic;
using System.Text;
using RobotSimulatorLibrary.Position;

namespace RobotSimulatorLibrary.Interfaces
{
    public interface ILocationCalculator
    {
        (Location location,bool found) GetLocation(Position.Position position,int lateralSpeed);
    }
}
