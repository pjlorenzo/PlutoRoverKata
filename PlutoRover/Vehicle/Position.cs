using PlutoRover.Enums;
using PlutoRover.PlanetMap;

namespace PlutoRover.Vehicle
{
    public class Position : IPosition
    {
        private PlutoMap _map;
        
        public int x { get; set; }
        public int y { get; set; }
        public Orientation Orientation { get; set; }

        public Position()
        {
            
        }
    }
}