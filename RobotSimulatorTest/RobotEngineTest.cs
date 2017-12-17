using System;
using Autofac;
using RobotSimulatorLibrary;
using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Commands.CommandParsers;
using RobotSimulatorLibrary.Factories;
using RobotSimulatorLibrary.Interfaces;
using Xunit;

namespace RobotSimulatorTest
{
    public class RobotSimulatorTest
    {
        [Fact]
        public void WhenPlacedOriginFacingNorth_MoveAndOtherMoves()
        {
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
             robotEngine.Execute("PLACE 0,0,NORTH");
             robotEngine.Execute("MOVE");
            robotEngine.Execute("LEFT");
            robotEngine.Execute("RIGHT");
            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(Direction.North, robot.CurrentPosition.Direction);
            Assert.Equal(0, robot.CurrentPosition.Location.X);
            Assert.Equal(1, robot.CurrentPosition.Location.Y);
        }

        [Fact]
        public void WhenPlacedOriginFacingNorth_Move()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 0,0,NORTH");
            robotEngine.Execute("MOVE");
            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(Direction.North, robot.CurrentPosition.Direction);
            Assert.Equal(0, robot.CurrentPosition.Location.X);
            Assert.Equal(1, robot.CurrentPosition.Location.Y);
        }

        [Fact]
        public void WhenPlacedOriginFacingNorth_Left()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 0,0,NORTH");
            robotEngine.Execute("LEFT");
            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(Direction.West, robot.CurrentPosition.Direction);
            Assert.Equal(0, robot.CurrentPosition.Location.X);
            Assert.Equal(0, robot.CurrentPosition.Location.Y);
        }
        [Fact]
        public void WhenPlacedOriginFacingNorth_Move_Move_Left_Move()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,2,EAST");
            robotEngine.Execute("MOVE");
            robotEngine.Execute("MOVE");
            robotEngine.Execute("LEFT");
            robotEngine.Execute("MOVE");
            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(Direction.North, robot.CurrentPosition.Direction);
            Assert.Equal(3, robot.CurrentPosition.Location.X);
            Assert.Equal(3, robot.CurrentPosition.Location.Y);
        }

    }
}
