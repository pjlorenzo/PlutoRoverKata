using System;
using FluentAssertions;
using NUnit.Framework;
using PlutoRover.Enums;
using PlutoRover.Vehicle;

namespace PlutoRover.Unit.Tests
{
    public class RoverTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(0, 0, Orientation.N, "0,1,N")]
        [TestCase(50, 50, Orientation.E, "51,50,E")]
        [TestCase(50, 50, Orientation.S, "50,49,S")]
        [TestCase(50, 50, Orientation.W, "49,50,W")]
        public void Rover_WhenMoveForwardIsCalled_ThenUpdatePosition(int positionX, int positionY, Orientation orientation, string result)
        {
            var initialPosition = new Position{x = positionX, y = positionY, Orientation = orientation};
            var rover = new Rover(initialPosition);
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
            var rover = new Rover(initialPosition);
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

            var rover = new Rover(initialPosition);
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

            var rover = new Rover(initialPosition);
            rover.TurnRight();
            rover.PositionReported.Should().Be(result);
        }
    }
}