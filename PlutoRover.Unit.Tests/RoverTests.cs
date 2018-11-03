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
        public void Rover_WhenMoveBackwardIsCalled_ThenMoveBackwardByOneNoChangeOnDirection()
        {
            var initialPosition = new Position { x = 50, y = 50, Orientation = Orientation.N };
            var rover = new Rover(initialPosition);
            rover.MoveBackward();
            rover.PositionReported.Should().Be("50,49,N");
        }
    }
}