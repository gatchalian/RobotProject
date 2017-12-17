using System;
using System.Collections.Generic;
using System.Text;
using RobotSimulatorLibrary;
using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Consumers
{
    public class ConsoleTextConsumer : BaseConsumer
    {

        public ConsoleTextConsumer(IRobotEngine robotEngine, IDisplayConsole displayConsole) : base(robotEngine, displayConsole)
        {
            RobotEngine = robotEngine;
        }


        public override void StartProcessing(string parameter)
        {
            DisplayConsole.ShowMessage("You can use file input by typing RobotSimulor <FilePath>\r\nWaiting for command...\r\nPress ENTER to exit");
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                else
                    this.OnNext(input);
            }
        }
    }
}
