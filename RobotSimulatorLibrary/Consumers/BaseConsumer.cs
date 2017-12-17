using System;
using System.Collections.Generic;
using System.Text;
using RobotSimulatorLibrary;
using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Consumers
{
    public abstract class BaseConsumer:IConsumers
    {
        protected IRobotEngine RobotEngine;
        protected bool Finished = false;
        protected IDisplayConsole DisplayConsole;

        protected BaseConsumer(IRobotEngine robotEngine, IDisplayConsole displayConsole)
        {
            RobotEngine = robotEngine;
            DisplayConsole = displayConsole;
        }
        public void OnCompleted()
        {
            if (Finished)
            {
                OnError(new Exception("This consumer already _finished it's lifecycle"));
                return;
            }
            Finished = true;
        }


        public void OnError(Exception error)
        {
            Console.WriteLine("<- ERROR");
            Console.WriteLine("<- {0}", error.Message);
        }


        public void OnNext(string value)
        {
            if (Finished)
            {
                OnError(new Exception("This consumer _finished its lifecycle"));
                return;
            }
            RobotEngine.Execute(value);
        }

        public abstract void StartProcessing(string parameter);

    }
}
