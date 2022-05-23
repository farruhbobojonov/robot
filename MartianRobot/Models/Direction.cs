using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobot
{
    public enum Orientation { E, N, W, S}
    public enum Instruction { L, R, F }

    public class Direction
    {
        private Orientation _Line;

        public Orientation Line { get => _Line; set => _Line = value; }

        public Direction(char orientation)
        { 
            this.Line = SetOrientation(orientation);
        }

        private Orientation SetOrientation(char orientation)
        {
            Orientation orient;
            switch (orientation)
            {
                case 'N': orient = Orientation.N; break;
                case 'E': orient = Orientation.E; break;
                case 'S': orient = Orientation.S; break;
                default: orient = Orientation.W; break;
            }
            return orient;
        }
    }
}
