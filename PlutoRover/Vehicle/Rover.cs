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
            var newPosition = 0;
            var finalPosition = 0;
            switch (_position.Orientation)
            {
                case Orientation.N:
                    newPosition = _position.y + 1;
                    finalPosition = newPosition > _plutoMap.SizeY ? newPosition - _plutoMap.SizeY - 1 : newPosition;
                    _position.y = finalPosition;
                    break;
                case Orientation.E:
                {
                    newPosition = _position.x + 1;
                    finalPosition = newPosition > _plutoMap.SizeX ? newPosition - _plutoMap.SizeX - 1 : newPosition;    
                    _position.x=finalPosition;
                    break;
                }
                case Orientation.S:
                    newPosition = _position.y - 1;
                    finalPosition = newPosition < 0 ? _plutoMap.SizeY : newPosition;
                    _position.y = finalPosition;
                    break;
                case Orientation.W:
                    newPosition = _position.x - 1;
                    finalPosition = newPosition < 0 ?  _plutoMap.SizeX : newPosition;
                    _position.x = finalPosition;
                    break;
            }
        }


        public void MoveBackward()
        {
            var newPosition = 0;
            var finalPosition = 0;
            switch (_position.Orientation)
            {
                case Orientation.N:
                    newPosition = _position.y - 1;
                    finalPosition = newPosition < 0 ? _plutoMap.SizeY : newPosition;
                    _position.y = finalPosition;
                    break;
                case Orientation.E:
                    newPosition = _position.x - 1;
                    finalPosition = newPosition < 0 ? _plutoMap.SizeX : newPosition;
                    _position.x = finalPosition ; 
                    break;
                case Orientation.S:
                    newPosition = _position.y + 1;
                    finalPosition = newPosition > _plutoMap.SizeY ? newPosition - _plutoMap.SizeY - 1 : newPosition;
                    _position.y = finalPosition;
                        break;
                case Orientation.W:
                    newPosition = _position.x + 1;
                        finalPosition = newPosition > _plutoMap.SizeX ? newPosition - _plutoMap.SizeX -1 : newPosition;
                    _position.x= finalPosition;
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