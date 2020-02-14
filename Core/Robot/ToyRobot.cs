using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Robot
{
    public class ToyRobot : IRobot
    {
        public Direction CurrentDirection { get; set; }
        public Position Position { get; private set; }

        public ToyRobot()
        {
        }

        public void Place(int x, int y, Direction direction)
        {
            Place(x, y);
            CurrentDirection = direction;
        }

        public void Place(int x, int y)
        {
            Position = new Position();
            Position.X = x;
            Position.Y = y;
        }

        public Position CalculateNextPosition()
        {
            var currentPosition = (Position)Position.Clone();
            switch (CurrentDirection)
            {
                case Direction.North:
                    currentPosition.Y++;
                    break;

                case Direction.East:
                    currentPosition.X++;
                    break;

                case Direction.South:
                    currentPosition.Y--;
                    break;

                case Direction.West:
                    currentPosition.X--;
                    break;
            }

            return currentPosition;
        }

        public void Rotate(Rotation rotation)
        {
            switch (rotation)
            {
                case Rotation.Left:
                    CurrentDirection = CurrentDirection - 1 < Direction.North ? Direction.West : CurrentDirection - 1;
                    break;

                case Rotation.Right:
                    CurrentDirection = CurrentDirection + 1 > Direction.West ? Direction.North : CurrentDirection + 1;
                    break;
            }
        }
    }
}