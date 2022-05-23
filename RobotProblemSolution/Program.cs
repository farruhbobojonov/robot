using MartianRobot;
using System;
using System.Collections.Generic;

namespace RobotProblemSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string gridInputs = "5 3";

            string currentPositionOfRobotInputs = "0 3 W"; 
            string commandInputs = "LLFFFLFLFL";
           
            Grid grid = new Grid(
                new Coordinate 
                { 
                    X = int.Parse(gridInputs.Split(" ")[0]),
                    Y = int.Parse(gridInputs.Split(" ")[1])
                });

            Robot robot = new Robot(new Position
            {
                Coordinate = new Coordinate
                {
                    X = int.Parse(currentPositionOfRobotInputs.Split(" ")[0]),
                    Y = int.Parse(currentPositionOfRobotInputs.Split(" ")[1])
                },
                Direction = new Direction(currentPositionOfRobotInputs.Split(" ")[2].ToCharArray()[0])
            });

            robot.Grid = grid;

            char[] commands = commandInputs.ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                if (robot.IsLost)
                {
                    break;
                }

                robot.SetCommand(commands[i]);

                robot.ExecuteCommand();    
            }

            var lost = (robot.IsLost) ? "LOST" : "";

            Console.WriteLine($"{robot.Position.Coordinate.X} {robot.Position.Coordinate.Y} {robot.Position.Direction.Line} {lost}");

            Console.ReadKey();
        }
    }
}
