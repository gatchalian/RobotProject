using Autofac;
using RobotSimulatorLibrary.Calculators;
using RobotSimulatorLibrary.Calculators.Visitors;
using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Commands.CommandParsers;
using RobotSimulatorLibrary.Commands.Concrete;
using RobotSimulatorLibrary.Consoles;
using RobotSimulatorLibrary.Consumers;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.RobotStates;

namespace RobotSimulatorLibrary.Factories
{
    public static class  RegistrationService
    {
        public static IContainer Container { get; set; }
        public static int TableWidth { get; set; }
        public static int TableHeight { get; set; }
        public static int LateralSpeed { get; set; }

        public static void Register()
        {
            var builder = new ContainerBuilder();
            var width = TableWidth;
            var height = TableHeight;
            var lateralSpeed = LateralSpeed; 
            builder.Register(c => new Table(width, height)).As<ITable>();
            builder.Register(c => new Inactive(c.Resolve<IRobot>(),c.ResolveKeyed<ICalculator>("InactiveCalculatorVisitor"))).Keyed<IState>(nameof(Inactive));
            builder.RegisterType<MessageConsole>().As<IDisplayConsole>();
            builder.Register(c => new Robot(c.Resolve<ITable>(), lateralSpeed,c.Resolve<IDisplayConsole>())).As<IRobot>().SingleInstance();
            builder.RegisterType<CommandBroker>();
            builder.RegisterType<RobotEngine>().As<IRobotEngine>();

            builder.Register(c => new PlaceParser(StringConstants.Place,c.ResolveKeyed<ICommandParser>(nameof(MoveParser)))).Keyed<ICommandParser>(nameof(PlaceParser));
            builder.Register(c => new MoveParser(StringConstants.Move, c.ResolveKeyed<ICommandParser>(nameof(LeftParser)))).Keyed<ICommandParser>(nameof(MoveParser));
            builder.Register(c => new LeftParser(StringConstants.Left, c.ResolveKeyed<ICommandParser>(nameof(RightParser)))).Keyed<ICommandParser>(nameof(LeftParser));
            builder.Register(c => new RightParser(StringConstants.Right, c.ResolveKeyed<ICommandParser>(nameof(ReportParser)))).Keyed<ICommandParser>(nameof(RightParser));
            builder.Register(c => new ReportParser(StringConstants.Report,null)).Keyed<ICommandParser>(nameof(ReportParser));

            builder.RegisterType<Place>().Keyed<ICommand>(StringConstants.Place);
            builder.RegisterType<Move>().Keyed<ICommand>(StringConstants.Move);
            builder.RegisterType<Left>().Keyed<ICommand>(StringConstants.Left);
            builder.RegisterType<Right>().Keyed<ICommand>(StringConstants.Right);
            builder.RegisterType<Report>().Keyed<ICommand>(StringConstants.Report);


            builder.Register(c => new ReportVisitor(c.Resolve<IRobot>(), null)).Keyed<ICalculator>(nameof(ReportVisitor));
            builder.Register(c => new PlacePositionCalculator(c.Resolve<IRobot>(), c.ResolveKeyed<ICalculator>(nameof(ReportVisitor)))).Keyed<ICalculator>(nameof(PlacePositionCalculator));

            builder.Register(c => new PositionCalculatorVisitor(c.Resolve<IRobot>(),c.ResolveKeyed<ICalculator>(nameof(PlacePositionCalculator)))).Keyed<ICalculator>("InactiveCalculatorVisitor").InstancePerLifetimeScope();

            builder.RegisterType<MessageConsole>().As<IDisplayConsole>();
            builder.Register(c=> new FileTextConsumer(c.Resolve<IRobotEngine>(),c.Resolve<IDisplayConsole>())).Keyed<IConsumers>(nameof(FileTextConsumer));
            builder.Register(c => new ConsoleTextConsumer(c.Resolve<IRobotEngine>(), c.Resolve<IDisplayConsole>())).Keyed<IConsumers>(nameof(ConsoleTextConsumer));

            Container = builder.Build();


        }
    }
}
