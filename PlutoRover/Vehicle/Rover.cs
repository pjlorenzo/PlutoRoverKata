using System;
using PlutoRover.Enums;

namespace PlutoRover.Vehicle
{
    public class Rover
    {
        private Position _position;

        public string PositionReported { get; set; }

        public Rover(Position position)
        {
            _position = position;
        }

        public void MoveForward()
        {
            if (_position.Orientation == Orientation.N)
            {
                _position.y++;
            }
            if (_position.Orientation == Orientation.E)
            {
                _position.x++;
            }
            if (_position.Orientation == Orientation.S)
            {
                _position.y--;
            }
            if (_position.Orientation == Orientation.W)
            {
                _position.x--;
            }
            PositionReported = $"{_position.x},{_position.y},{_position.Orientation}";
        }


        public void MoveBackward()
        {
            if (_position.Orientation == Orientation.N)
            {
                _position.y--;
            }

            PositionReported = $"{_position.x},{_position.y},{_position.Orientation}";
        }
    }
}