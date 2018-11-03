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
        public void Rover_WhenMoveForwardIsCalled_ThenUpdatePosition()
        {
            var initialPosition = new Position{x = 0, y = 0, Orientation = Orientation.N};
            var rover = new Rover(initialPosition);
            rover.MoveForward();
            rover.PositionReported.Should().Be("0,1,N");
        }
    }
}