using MartianRobot;
using System;
using Xunit;

namespace Tests
{
    public class UnitTest
    {
        [Fact]
        public void Test1()
        {
            string result = Helper.DoProcess("5 3", "1 1 E", "RFRFRFRF");

            Assert.Equal("1 1 E", result.Trim());
        }

        [Fact]
        public void Test2()
        {
            string result = Helper.DoProcess("5 3", "3 2 N", "FRRFLLFFRRFLL");

            Assert.Equal("3 3 N LOST", result.Trim());
        }

        [Fact]
        public void Test3()
        {
            string result = Helper.DoProcess("5 3", "0 3 W", "LLFFFLFLFL");

            Assert.Equal("3 3 N LOST", result.Trim());
        }
    }
}
