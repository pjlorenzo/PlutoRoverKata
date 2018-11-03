using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using PlutoRover.PlanetMap;

namespace PlutoRover.Unit.Tests
{
    public class PlutoMapTests
    {
        [Test]
        public void ShouldImplementIPlanetMap()
        {
            typeof(PlutoMap).Should().BeAssignableTo<IPlanetMap>();
        }
        [Test]
        public void Constructor_WhenClassIsInitializedWithoutParameters_ShouldUseTheDefaults()
        {
            var pluto = new PlutoMap();

            pluto.SizeX.Should().Be(99);
            pluto.SizeY.Should().Be(99);
            pluto.Obstacles.Count.Should().Be(0);
        }

        [Test]
        public void Constructor_WhenClassIsInitializedWithParameters_ShouldReturnProperValues()
        {
            var sizeX = 200;
            var sizeY = 200;

            var obstacles = new List<Obstacle>
            {
                new Obstacle{LocationX = 10, LocationY = 15}
            };

            var pluto = new PlutoMap(sizeX, sizeY, obstacles);

            pluto.SizeX.Should().Be(sizeX - 1);
            pluto.SizeY.Should().Be(sizeY - 1);
            obstacles.Count.Should().Be(1);
        }
    }
}
