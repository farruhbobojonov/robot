using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobot
{
    public class Position
    {
        private Coordinate _Coordinate;
        private Direction _Direction;

        public Coordinate Coordinate { get => _Coordinate; set => _Coordinate = value; }
        public Direction Direction { get => _Direction; set => _Direction = value; }
    }
}
