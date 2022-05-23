using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobot
{
    public class Engine
    {
        private Robot _Robot;
        private List<Orientation> Compass = new List<Orientation> { Orientation.W, Orientation.N, Orientation.E, Orientation.S };
        private Instruction _Command;
        
        public Instruction Command { private get => _Command; set => _Command = value; }
        public Robot Robot { get => _Robot; private set => _Robot = value; }

        public Engine(Robot robot)
        { 
            Robot = robot;
        }

        private Orientation GetOrientation(int indexOfCompassOrientation)
        { 
            return Compass[indexOfCompassOrientation];
        }

        private void TurnLeft(int indexOfCompassOrientation)
        {
            if (indexOfCompassOrientation == 0)
            {
                indexOfCompassOrientation = 3;
            }
            else
            {
                indexOfCompassOrientation--;
            }
            Robot.Position.Direction.Line = Compass[indexOfCompassOrientation];
        }

        private void TurnRight(int indexOfCompassOrientation)
        {
            if (indexOfCompassOrientation == 3)
            {
                indexOfCompassOrientation = 0;
            }
            else
            {
                indexOfCompassOrientation++;
            }
            Robot.Position.Direction.Line = Compass[indexOfCompassOrientation];
        }

        private void GoForward(int indexOfCompassOrientation)
        {
            switch (GetOrientation(indexOfCompassOrientation))
            {
                case Orientation.W:
                    if (Robot.Position.Coordinate.X == 0)
                    {
                        Robot.Grid.AddScent(Robot.Position.Coordinate);
                        Robot.IsLost = true;
                    }
                    else
                    {
                        Robot.Position.Coordinate.X--;
                    }
                    break;
                case Orientation.N:
                    if (Robot.Position.Coordinate.Y == Robot.Grid.Edge.Y)
                    {
                        Robot.Grid.AddScent(Robot.Position.Coordinate);
                        Robot.IsLost = true;
                    }
                    else
                    {
                        Robot.Position.Coordinate.Y++;
                    }
                    break;
                case Orientation.E:
                    if (Robot.Position.Coordinate.X == Robot.Grid.Edge.X)
                    {
                        Robot.Grid.AddScent(Robot.Position.Coordinate);
                        Robot.IsLost = true;
                    }
                    else
                    {
                        Robot.Position.Coordinate.X++;
                    }
                    break;
                case Orientation.S:
                    if (Robot.Position.Coordinate.Y == 0)
                    {
                        Robot.Grid.AddScent(Robot.Position.Coordinate);
                        Robot.IsLost = true;
                    }
                    else
                    {
                        Robot.Position.Coordinate.Y--;
                    }
                    break;
            }
        }
        public void SetCommand(char command)
        {
            switch (command)
            {
                case 'L': Command = Instruction.L; break;
                case 'R': Command = Instruction.R; break;
                case 'F': Command = Instruction.F; break;
            }
        }

        public void Drive()
        {
            var compassOrientation = Compass.IndexOf(Robot.Position.Direction.Line);

            switch (Command)
            {
                case Instruction.L:

                    TurnLeft(compassOrientation);

                    break;

                case Instruction.R:

                    TurnRight(compassOrientation);

                    break;

                case Instruction.F:

                    GoForward(compassOrientation);

                    break;
            }
        }    
    }
}
