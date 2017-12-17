using System;
using System.Collections.Generic;
using System.Text;

namespace RobotSimulatorLibrary.Interfaces
{
    public interface IConsumers:IObserver<string>
    {
        void StartProcessing(string parameter);
    }
}
