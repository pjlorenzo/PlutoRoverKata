using System;
using PlutoRover.Enums;

namespace PlutoRover.Vehicle
{
    public class Rover
    {
        private IPosition _position;

        public string PositionReported
        {
            get
            {
                return $"{_position.x},{_position.y},{_position.Orientation}";
            }
        }

        public Rover(IPosition position)
        {
            _position = position;
        }

        public void MoveForward()
        {
            switch (_position.Orientation)
            {
                case Orientation.N:
                    _position.y++;
                    break;
                case Orientation.E:
                    _position.x++;
                    break;
                case Orientation.S:
                    _position.y--;
                    break;
                case Orientation.W:
                    _position.x--;
                    break;
            }
        }


        public void MoveBackward()
        {
            switch (_position.Orientation)
            {
                case Orientation.N:
                    _position.y--;
                    break;
                case Orientation.E:
                    _position.x--; ;
                    break;
                case Orientation.S:
                    _position.y++;
                        break;
                case Orientation.W:
                    _position.x++;
                        break;               
            }
        }

        public void TurnLeft()
        {
            switch (_position.Orientation)
            {
                case Orientation.N:
                    _position.Orientation = Orientation.W;
                    break;
                case Orientation.W:
                    _position.Orientation = Orientation.S;
                    break;
                case Orientation.S:
                    _position.Orientation = Orientation.E;
                    break;
                case Orientation.E:
                    _position.Orientation = Orientation.N;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (_position.Orientation)
            {
                case Orientation.N:
                    _position.Orientation = Orientation.E;
                    break;
                case Orientation.E:
                    _position.Orientation = Orientation.S;
                    break;
                    break;
                case Orientation.S:
                    _position.Orientation = Orientation.W;
                    break;
                case Orientation.W:
                    _position.Orientation = Orientation.N;
                    break;
            }
        }
    }
}