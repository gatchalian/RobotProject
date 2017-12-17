namespace RobotSimulatorLibrary.Position
{
    public class Position
    {
        public Position(Location location, Direction direction)
        {
            Location = location;
            Direction = direction;
        }

        public Location Location { get; private set; }

        public Direction Direction { get; private set; }
    }
}
