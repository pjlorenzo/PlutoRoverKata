using System;
using PlutoRover.Enums;
using PlutoRover.PlanetMap;

namespace PlutoRover.Vehicle
{
    public class Rover
    {
        private IPosition _position;
        private readonly PlutoMap _plutoMap;

        public string PositionReported
        {
            get
            {
                return $"{_position.x},{_position.y},{_position.Orientation}";
            }
        }

        public Rover(IPosition position, PlutoMap plutoMap)
        {
            _position = position;
            _plutoMap = plutoMap;
        }

        public void MoveForward()
        {
            switch (_position.Orientation)
            {
                case Orientation.N:
                    _position.y++;
                    break;
                case Orientation.E:
                {
                    var newposition = _position.x + 1;
                     var finalPosition = newposition > _plutoMap.SizeX ? newposition - _plutoMap.SizeX - 1 : newposition;
                        
                    _position.x=finalPosition;
                    break;
                }
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