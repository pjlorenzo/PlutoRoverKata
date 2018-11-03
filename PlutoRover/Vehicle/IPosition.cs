using PlutoRover.Enums;

namespace PlutoRover.Vehicle
{
    public interface IPosition
    {
        int x { get; set; }
        int y { get; set; }
        Orientation Orientation { get; set; }
    }
}