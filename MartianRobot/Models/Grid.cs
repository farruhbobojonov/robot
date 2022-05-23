using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobot
{
    public class Grid
    {
        private Coordinate _Edge;
        private List<Coordinate> _Scents;
        public Coordinate Edge { get => _Edge; private set => _Edge = value; }
        public List<Coordinate> Scents { get => _Scents; private set => _Scents = value; }

        public Grid(Coordinate edge)
        { 
            this.Edge = edge;
            this.Scents = new List<Coordinate>();
        }
        
        // Adds scents as unique. 
        public void AddScent(Coordinate value)
        {
            int index = this.Scents.BinarySearch(value);

            if (index < 0)
            {
                this.Scents.Insert(~index, value);
            }
        }
    }
}
