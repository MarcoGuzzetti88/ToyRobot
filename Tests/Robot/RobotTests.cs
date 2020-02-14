using Core.Robot;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.Robot
{
    public class RobotTests
    {
        [Fact]
        public void Robot_Ctor_PlaceIn0_0_N_VerifyCurrentX()
        {
            var robot = new ToyRobot();
            robot.Place(0, 0, Domain.Direction.North);

            Assert.Equal(0, robot.Position.X);
        }

        [Fact]
        public void Robot_Ctor_PlaceIn0_0_N_VerifyCurrentY()
        {
            var robot = new ToyRobot();
            robot.Place(0, 0, Domain.Direction.North);

            Assert.Equal(0, robot.Position.Y);
        }

        [Fact]
        public void Robot_Ctor_PlaceIn0_0_N_VerifyCurrentDirection()
        {
            var robot = new ToyRobot();
            robot.Place(0, 0, Domain.Direction.North);

            Assert.Equal(Domain.Direction.North, robot.CurrentDirection);
        }

        [Fact]
        public void Rotate_CurrentDirectionNorthMoveRight_CurrentDirectionEast()
        {
            var robot = new ToyRobot();
            robot.Place(0, 0, Domain.Direction.North);
            robot.Rotate(Domain.Rotation.Right);

            Assert.Equal(Domain.Direction.East, robot.CurrentDirection);
        }

        [Fact]
        public void Rotate_CurrentDirectionWestMoveRight_CurrentDirectionNorth()
        {
            var robot = new ToyRobot();
            robot.Place(0, 0, Domain.Direction.West);
            robot.Rotate(Domain.Rotation.Right);

            Assert.Equal(Domain.Direction.North, robot.CurrentDirection);
        }

        [Fact]
        public void Rotate_CurrentDirectionNorthMoveLeft_CurrentDirectionWest()
        {
            var robot = new ToyRobot();
            robot.Place(0, 0, Domain.Direction.North);
            robot.Rotate(Domain.Rotation.Left);

            Assert.Equal(Domain.Direction.West, robot.CurrentDirection);
        }

        [Fact]
        public void Rotate_CurrentDirectionWestMoveLeft_CurrentDirectionSouth()
        {
            var robot = new ToyRobot();
            robot.Place(0, 0, Domain.Direction.West);
            robot.Rotate(Domain.Rotation.Left);

            Assert.Equal(Domain.Direction.South, robot.CurrentDirection);
        }

        [Fact]
        public void Move_RobotIn0_0_N_RobotIn0_1_N_XIs0()
        {
            var robot = new ToyRobot();
            robot.Place(0, 0, Domain.Direction.North);
            var nextPosition = robot.CalculateNextPosition();
            Assert.Equal(0, nextPosition.X);
        }

        [Fact]
        public void Move_RobotIn0_0_N_RobotIn0_1_N_XIs1()
        {
            var robot = new ToyRobot();
            robot.Place(0, 0, Domain.Direction.North);
            var nextPosition = robot.CalculateNextPosition();
            Assert.Equal(1, nextPosition.Y);
        }

        [Fact]
        public void Move_RobotIn0_0_N_RobotIn0_1_N_DirectionIsNorth()
        {
            var robot = new ToyRobot();
            robot.Place(0, 0, Domain.Direction.North);
            var newPosition = robot.CalculateNextPosition();
            robot.Place(newPosition.X, newPosition.Y);
            Assert.Equal(Domain.Direction.North, robot.CurrentDirection);
        }
    }
}