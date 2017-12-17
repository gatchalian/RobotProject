using System;
using System.IO;
using RobotSimulatorLibrary.Interfaces;


namespace RobotSimulatorLibrary.Consumers
{
    public class FileTextConsumer: BaseConsumer
    {
        public FileTextConsumer(IRobotEngine robotEngine,IDisplayConsole displayConsole):base(robotEngine,displayConsole)
        {
        }

        public override void StartProcessing(string filePath)
        {
            DisplayConsole.ShowMessage("You can run commands from the console by removing the filepath argument when starting this application.");
            if (!File.Exists(filePath))
            {
                DisplayConsole.ShowMessage($"The file {filePath} does not exist.\r\n Please check that you have entered the proper path.");
                return;
            }

            DisplayConsole.ShowMessage($"Processing commands from {filePath}");
            var lines = File.ReadLines(filePath);
            foreach (var input in lines)
            {
                DisplayConsole.ShowMessage($"Command: {input}");
                if (string.IsNullOrEmpty(input))
                    break;
                else
                    this.OnNext(input);
            }

        }

    }
}
