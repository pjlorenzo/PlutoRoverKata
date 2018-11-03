using System.Collections.Generic;

namespace PlutoRover.PlanetMap
{
    public class PlutoMap : IPlanetMap
    {
        private List<Obstacle> obstacles;

        public int SizeX { get; set; } = 99;
        public int SizeY { get; set; } = 99;
        public List<Obstacle> Obstacles { get; set; }

        public PlutoMap()
        {
            Obstacles = new List<Obstacle>();
        }

        public PlutoMap(int sizeX, int sizeY, List<Obstacle> obstacles)
        {
            SizeX = sizeX - 1;
            SizeY = sizeY - 1;
            Obstacles = obstacles;
        }
    }
}