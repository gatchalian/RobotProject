using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.RobotStates
{
    public class Placed:BaseState
    {
        public Placed(IRobot robot,ICalculator calculator):base(robot,calculator) 
        {
        }
    }
}
