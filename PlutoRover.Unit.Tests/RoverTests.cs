using System;
using FluentAssertions;
using NUnit.Framework;
using PlutoRover.Enums;
using PlutoRover.PlanetMap;
using PlutoRover.Vehicle;

namespace PlutoRover.Unit.Tests
{
    public class RoverTests
    {
        private PlutoMap plutoMap;
        [SetUp]
        public void Setup()
        {
            
            plutoMap = new PlutoMap();
        }

        [Test]
        [TestCase(0, 0, Orientation.N, "0,1,N")]
        [TestCase(50, 50, Orientation.E, "51,50,E")]
        [TestCase(50, 50, Orientation.S, "50,49,S")]
        [TestCase(50, 50, Orientation.W, "49,50,W")]
        public void Rover_WhenMoveForwardIsCalled_ThenUpdatePosition(int positionX, int positionY, Orientation orientation, string result)
        {
            
            var initialPosition = new Position{x = positionX, y = positionY, Orientation = orientation};
            var rover = new Rover(initialPosition,plutoMap);
            rover.MoveForward();
            rover.PositionReported.Should().Be(result);
        }

        [Test]
        [TestCase(50, 50, Orientation.N, "50,49,N")]
        [TestCase(50, 50, Orientation.E, "49,50,E")]
        [TestCase(50, 50, Orientation.S, "50,51,S")]
        [TestCase(50, 50, Orientation.W, "51,50,W")]
        public void Rover_WhenMoveBackwardIsCalled_ThenMoveBackwardByOneNoChangeOnDirection(int positionX, int positionY, Orientation orientation, string result)
        {
            
            var initialPosition = new Position { x = positionX, y = positionY, Orientation = orientation };
            var rover = new Rover(initialPosition, plutoMap);
            rover.MoveBackward();
            rover.PositionReported.Should().Be(result);
        }

        [Test]
        [TestCase(50,50,Orientation.N, "50,50,W")]
        [TestCase(50,50,Orientation.W, "50,50,S")]
        [TestCase(50,50,Orientation.S, "50,50,E")]
        [TestCase(50,50,Orientation.E, "50,50,N")]
        public void Rover_WhenMoveLeft_ThenChangeDirection(int positionX, int positionY, Orientation orientation, string result)
        {
            
            var initialPosition = new Position
            {
                x = positionX,
                y = positionY,
                Orientation = orientation
            };

            var rover = new Rover(initialPosition, plutoMap);
            rover.TurnLeft();
            rover.PositionReported.Should().Be(result);
        }
        [Test]
        [TestCase(50, 50, Orientation.N, "50,50,E")]
        [TestCase(50, 50, Orientation.E, "50,50,S")]
        [TestCase(50, 50, Orientation.S, "50,50,W")]
        [TestCase(50, 50, Orientation.W, "50,50,N")]
        public void Rover_WhenTurnRight_ThenChangeDirection(int positionX, int positionY, Orientation orientation, string result)
        {
            
            var initialPosition = new Position
            {
                x = positionX,
                y = positionY,
                Orientation = orientation
            };

            var rover = new Rover(initialPosition, plutoMap);
            rover.TurnRight();
            rover.PositionReported.Should().Be(result);
        }
        [Test]
        [TestCase(99,5,Orientation.E, "0,5,E")]
        [TestCase(5,99,Orientation.N, "5,0,N")]
        [TestCase(0,5,Orientation.W, "99,5,W")]
        [TestCase(5,0,Orientation.S, "5,99,S")]
        public void Rover_WhenMoveForwardIsCalled_AndTheRoverIsInTheEdge_ThenUpdateThePosition(int positionX, int positionY, Orientation orientation, string result)
        {
            
            var initialPosition = new Position
            {
                x = positionX,
                y = positionY,
                Orientation = orientation
            };

            var rover = new Rover(initialPosition, plutoMap);

            rover.MoveForward();

            rover.PositionReported.Should().Be(result);

        }
        [Test]
        [TestCase(5, 0, Orientation.N, "5,99,N")]
        [TestCase(5, 99, Orientation.S, "5,0,S")]
        [TestCase(0, 5, Orientation.E, "99,5,E")]
        [TestCase(99, 5, Orientation.W, "0,5,W")]
        public void Rover_WhenMoveBackwardIsCalled_AndTheRoverIsInTheEdge_ThenUpdateThePosition(int positionX, int positionY, Orientation orientation, string result)
        {

            var initialPosition = new Position
            {
                x = positionX,
                y = positionY,
                Orientation = orientation
            };

            var rover = new Rover(initialPosition, plutoMap);

            rover.MoveBackward();

            rover.PositionReported.Should().Be(result);

        }
    }
}