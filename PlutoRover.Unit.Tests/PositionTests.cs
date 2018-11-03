using FluentAssertions;
using NUnit.Framework;
using PlutoRover.PlanetMap;
using PlutoRover.Vehicle;

namespace PlutoRover.Unit.Tests
{
    public class PositionTests
    {
        [Test]
        public void ShouldImplementInterface()
        {
            typeof(Position).Should().BeAssignableTo<IPosition>();
        }
    }
}
