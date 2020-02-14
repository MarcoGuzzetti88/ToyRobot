using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Robot
{
    public interface IRobot
    {
        Position Position { get; }
        Direction CurrentDirection { get; }

        void Place(int x, int y, Direction direction);

        Position CalculateNextPosition();

        void Rotate(Rotation rotation);
    }
}