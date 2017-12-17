using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary
{
    public class Table: ITable
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Table(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
