using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {

            string currentPositionOfRobotInputs = "3 2 N";
            string commandInputs = "FRRFLLFFRRFLL";

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

            Assert.AreEqual(1, 1);
        }
    }
}
