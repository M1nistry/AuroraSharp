using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoleafHome.Helpers
{
    public class On
    {
        public bool value { get; set; }
    }

    public class Brightness
    {
        public int value { get; set; }
        public int max { get; set; }
        public int min { get; set; }
    }

    public class Hue
    {
        public int value { get; set; }
        public int max { get; set; }
        public int min { get; set; }
    }

    public class Sat
    {
        public int value { get; set; }
        public int max { get; set; }
        public int min { get; set; }
    }

    public class Ct
    {
        public int value { get; set; }
        public int max { get; set; }
        public int min { get; set; }
    }

    public class State
    {
        public On on { get; set; }
        public Brightness brightness { get; set; }
        public Hue hue { get; set; }
        public Sat sat { get; set; }
        public Ct ct { get; set; }
        public string colorMode { get; set; }
    }

    public class Effects
    {
        public string select { get; set; }
        public List<string> effectsList { get; set; }
    }

    public class PositionData
    {
        public int panelId { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int o { get; set; }
    }

    public class Layout
    {
        public int numPanels { get; set; }
        public int sideLength { get; set; }
        public List<PositionData> positionData { get; set; }
    }

    public class GlobalOrientation
    {
        public int value { get; set; }
        public int max { get; set; }
        public int min { get; set; }
    }

    public class PanelLayout
    {
        public Layout layout { get; set; }
        public GlobalOrientation globalOrientation { get; set; }
    }

    public class RhythmPos
    {
        public int x { get; set; }
        public int y { get; set; }
        public int o { get; set; }
    }

    public class Rhythm
    {
        public bool rhythmConnected { get; set; }
        public bool rhythmActive { get; set; }
        public int rhythmId { get; set; }
        public string hardwareVersion { get; set; }
        public string firmwareVersion { get; set; }
        public bool auxAvailable { get; set; }
        public int rhythmMode { get; set; }
        public RhythmPos rhythmPos { get; set; }
    }

    public class AuroraDevice
    {
        public string name { get; set; }
        public string serialNo { get; set; }
        public string manufacturer { get; set; }
        public string firmwareVersion { get; set; }
        public string model { get; set; }
        public State state { get; set; }
        public Effects effects { get; set; }
        public PanelLayout panelLayout { get; set; }
        public Rhythm rhythm { get; set; }
    }
}
