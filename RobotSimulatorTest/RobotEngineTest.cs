﻿using System;
using Autofac;
using RobotSimulatorLibrary;
using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Commands.CommandParsers;
using RobotSimulatorLibrary.Factories;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.RobotStates;
using Xunit;

namespace RobotSimulatorTest
{
    public class RobotSimulatorTest
    {
        //some positive tests
        [Fact]
        public void When_Place_CommandValidOrigin_FacingNorth_And_Move_Left_Right()
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
        public void When_Place_CommandValidOrigin_FacingNorth_And_Move()
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
        public void When_Place_CommandValidOrigin_FacingNorth_And_Left()
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
        public void When_Place_CommandValidOrigin_FacingEast_And_Move_Move_Left_Move()
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

        [Fact]
        public void When_InactiveState_And_InvalidEntry_Received()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("invalid command");

            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Inactive),robot.CurrentState.GetType());
        }

        [Fact]
        public void When_InactiveState_Valid_Place_Command_But_Invalid_Parameters()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE invalid parameters");

            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Inactive), robot.CurrentState.GetType());
        }

        [Fact]
        public void WhenInactiveAndValidPlaceCommand_Then_Placed_State()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,2,NORTH");

            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Placed), robot.CurrentState.GetType());
        }

        [Fact]
        public void WhenInactiveAndValidPlaceCommand_ExceedsHeight_Then_Inactive_State()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,6,NORTH");

            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Inactive), robot.CurrentState.GetType());
        }

        [Fact]
        public void WhenPlacedState_and_PlacedIn_ExceedingTableBounds()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,1,NORTH");
            robotEngine.Execute("PLACE 6,6,EAST");

            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Placed), robot.CurrentState.GetType());
            Assert.Equal(1,robot.CurrentPosition.Location.Y);
            Assert.Equal(1, robot.CurrentPosition.Location.X);
            Assert.Equal(Direction.North, robot.CurrentPosition.Direction);
        }

        [Fact]
        public void WhenMovedState_and_Placed_ExceedingTableBounds()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,1,NORTH");
            robotEngine.Execute("Move");
            robotEngine.Execute("PLACE 6,6,EAST");


            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Moved), robot.CurrentState.GetType());
            Assert.Equal(2, robot.CurrentPosition.Location.Y);
            Assert.Equal(1, robot.CurrentPosition.Location.X);
            Assert.Equal(Direction.North, robot.CurrentPosition.Direction);
        }

        [Fact]
        public void WhenMovedState_and_Left_ExceedingTableBounds()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,1,NORTH");
            robotEngine.Execute("Left");
            robotEngine.Execute("PLACE 6,6,EAST");


            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Turned), robot.CurrentState.GetType());
            Assert.Equal(1, robot.CurrentPosition.Location.Y);
            Assert.Equal(1, robot.CurrentPosition.Location.X);
            Assert.Equal(Direction.West, robot.CurrentPosition.Direction);
        }

        [Fact]
        public void WhenPlacedState_and_Right_ExceedingTableBounds()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,1,NORTH");
            robotEngine.Execute("Right");
            robotEngine.Execute("PLACE 6,6,EAST");


            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Turned), robot.CurrentState.GetType());
            Assert.Equal(1, robot.CurrentPosition.Location.Y);
            Assert.Equal(1, robot.CurrentPosition.Location.X);
            Assert.Equal(Direction.East, robot.CurrentPosition.Direction);
        }

        [Fact]
        public void WhenPlacedState_and_Placed_NegativeX()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,1,NORTH");
            robotEngine.Execute("PLACE -1,1,EAST");


            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Placed), robot.CurrentState.GetType());
            Assert.Equal(1, robot.CurrentPosition.Location.Y);
            Assert.Equal(1, robot.CurrentPosition.Location.X);
            Assert.Equal(Direction.North, robot.CurrentPosition.Direction);
        }

        [Fact]
        public void WhenPlacedState_and_Placed_NegativeY()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,1,NORTH");
            robotEngine.Execute("PLACE 1,-1,EAST");


            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Placed), robot.CurrentState.GetType());
            Assert.Equal(1, robot.CurrentPosition.Location.Y);
            Assert.Equal(1, robot.CurrentPosition.Location.X);
            Assert.Equal(Direction.North, robot.CurrentPosition.Direction);
        }

        [Fact]
        public void WhenPlacedState_and_Moved_NegativeX()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,1,NORTH");
            robotEngine.Execute("MOVE");
            robotEngine.Execute("PLACE -1,1,EAST");


            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Moved), robot.CurrentState.GetType());
            Assert.Equal(2, robot.CurrentPosition.Location.Y);
            Assert.Equal(1, robot.CurrentPosition.Location.X);
            Assert.Equal(Direction.North, robot.CurrentPosition.Direction);
        }

        [Fact]
        public void WhenPlacedState_and_Moved_NegativeY()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,1,NORTH");
            robotEngine.Execute("MOVE");
            robotEngine.Execute("PLACE 1,-1,EAST");


            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Moved), robot.CurrentState.GetType());
            Assert.Equal(2, robot.CurrentPosition.Location.Y);
            Assert.Equal(1, robot.CurrentPosition.Location.X);
            Assert.Equal(Direction.North, robot.CurrentPosition.Direction);
        }

        [Fact]
        public void WhenPlacedState_and_Left_NegativeX()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,1,NORTH");
            robotEngine.Execute("left");
            robotEngine.Execute("PLACE -1,1,EAST");


            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Turned), robot.CurrentState.GetType());
            Assert.Equal(1, robot.CurrentPosition.Location.Y);
            Assert.Equal(1, robot.CurrentPosition.Location.X);
            Assert.Equal(Direction.West, robot.CurrentPosition.Direction);
        }

        [Fact]
        public void WhenPlacedState_and_Left_NegativeY()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,1,NORTH");
            robotEngine.Execute("left");
            robotEngine.Execute("PLACE 1,-1,EAST");


            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Turned), robot.CurrentState.GetType());
            Assert.Equal(1, robot.CurrentPosition.Location.Y);
            Assert.Equal(1, robot.CurrentPosition.Location.X);
            Assert.Equal(Direction.West, robot.CurrentPosition.Direction);
        }

        [Fact]
        public void WhenPlacedState_and_Right_NegativeX()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,1,NORTH");
            robotEngine.Execute("right");
            robotEngine.Execute("PLACE -1,1,EAST");


            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Turned), robot.CurrentState.GetType());
            Assert.Equal(1, robot.CurrentPosition.Location.Y);
            Assert.Equal(1, robot.CurrentPosition.Location.X);
            Assert.Equal(Direction.East, robot.CurrentPosition.Direction);
        }

        [Fact]
        public void WhenPlacedState_and_Right_NegativeY()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,1,NORTH");
            robotEngine.Execute("right");
            robotEngine.Execute("PLACE 1,-1,EAST");


            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Turned), robot.CurrentState.GetType());
            Assert.Equal(1, robot.CurrentPosition.Location.Y);
            Assert.Equal(1, robot.CurrentPosition.Location.X);
            Assert.Equal(Direction.East, robot.CurrentPosition.Direction);
        }

        

        [Fact]
        public void WhenInactiveAndPlaced_With_Negative_Values()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE -1,-1,NORTH");


            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Inactive), robot.CurrentState.GetType());
        }

        [Fact]
        public void WhenInactiveAndPlaced_With_NegativeY()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 1,-1,NORTH");


            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Inactive), robot.CurrentState.GetType());
        }


        [Fact]
        public void WhenInactiveAndPlaced_With_NegativeX()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE -1,1,NORTH");


            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Inactive), robot.CurrentState.GetType());
        }



        [Fact]
        public void WhenInactiveAndValidPlaceCommand_ExceedsWidth_Then_Placed_State()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 6,1,EAST");

            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(typeof(Inactive), robot.CurrentState.GetType());
        }

        [Fact]
        public void WWhenPlacedNorthAndMovesAndExceedsTableHeight()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 0,0,NORTH");
            for (int i = 0; i < RegistrationService.TableHeight + 1; i++)
            {
                robotEngine.Execute("MOVE");
            }
            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(Direction.North, robot.CurrentPosition.Direction);
            Assert.Equal(0, robot.CurrentPosition.Location.X);
            Assert.Equal(5, robot.CurrentPosition.Location.Y);

        }

        [Fact]
        public void WWhenPlacedEastAndMovesAndExceedsTableHeight()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 0,0,EAST");
            for (int i = 0; i < RegistrationService.TableWidth + 1; i++)
            {
                robotEngine.Execute("MOVE");
            }
            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(Direction.East, robot.CurrentPosition.Direction);
            Assert.Equal(5, robot.CurrentPosition.Location.X);
            Assert.Equal(0, robot.CurrentPosition.Location.Y);

        }

        [Fact]
        public void WWhenPlacedWestAndMovesToExceedOrigin()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 0,0,WEST");
            for (int i = 0; i < RegistrationService.TableWidth + 1; i++)
            {
                robotEngine.Execute("MOVE");
            }
            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(Direction.West, robot.CurrentPosition.Direction);
            Assert.Equal(0, robot.CurrentPosition.Location.X);
            Assert.Equal(0, robot.CurrentPosition.Location.Y);

        }
        [Fact]
        public void WWhenPlacedSouthAndMovesToExceedOrigin()
        {
            RegistrationService.TableWidth = 5;
            RegistrationService.TableHeight = 5;
            RegistrationService.LateralSpeed = 1;
            RegistrationService.Register();
            var robotEngine = RegistrationService.Container.Resolve<IRobotEngine>();
            robotEngine.Execute("PLACE 0,0,SOUTH");
            for (int i = 0; i < RegistrationService.TableWidth + 1; i++)
            {
                robotEngine.Execute("MOVE");
            }
            var robot = RegistrationService.Container.Resolve<IRobot>();
            Assert.Equal(Direction.South, robot.CurrentPosition.Direction);
            Assert.Equal(0, robot.CurrentPosition.Location.X);
            Assert.Equal(0, robot.CurrentPosition.Location.Y);

        }
    }
}
