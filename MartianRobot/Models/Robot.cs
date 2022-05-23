using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobot
{
    public class Robot
    {
        private Engine _Engine;
        private Position _Position;
        private bool _IsLost;
        private Grid _Grid;

        public Position Position { get => _Position; private set => _Position = value; }
        public bool IsLost { get => _IsLost; set => _IsLost = value; }
        public Grid Grid { get => _Grid; set => _Grid = value; }

        public Robot(Position position)
        { 
            this.Position = position;
            this.IsLost = false;
            _Engine = new Engine(this);
        }
        public void SetCommand(char command)
        { 
            _Engine.SetCommand(command);
        }

        public void ExecuteCommand()
        { 
            _Engine.Drive();
        }
    }
}
