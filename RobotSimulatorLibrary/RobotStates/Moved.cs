using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using RobotSimulatorLibrary.Calculators.Visitors;
using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.RobotStates
{
    class Moved:BaseState
    {
        public Moved(IRobot robot,ICalculator calculator) : base(robot,calculator)
        {
        }
    }
}
