using PlutoRover.Enums;

namespace PlutoRover.Vehicle
{
    public class Position : IPosition
    {
        public int x { get; set; }
        public int y { get; set; }
        public Orientation Orientation { get; set; }
    }
}