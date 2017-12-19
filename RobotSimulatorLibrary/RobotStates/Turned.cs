using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using RobotSimulatorLibrary.Calculators.Visitors;
using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.RobotStates
{
    public class Turned:BaseState
    {
        public Turned(IRobot robot,ICalculator calculator) : base(robot,calculator)
        {
        }
    }
}
