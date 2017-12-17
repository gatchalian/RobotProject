using System;
using System.Collections.Generic;
using System.Text;
using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Consoles
{
    public class MessageConsole:IDisplayConsole
    {
        public void ShowMessage(string message)
        {
           Console.WriteLine(message);
        }
    }
}
