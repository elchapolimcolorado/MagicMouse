using MagicMouse.Sensor;

namespace MagicMouse
{
    public enum GesturesEnum
    {
        None, Right, Left, Up, Down, Clockwise, CounterclockWise
    }

    public static class Gestures
    {
        private static GesturesEnum lastGestures = GesturesEnum.None;

        public static GesturesEnum IdentifyGesture(SensorData sd)
        {
            GesturesEnum ge = GesturesEnum.None;
            if (sd.Gz > 200)
                ge = GesturesEnum.Left;
            if (sd.Gz < -200)
                ge = GesturesEnum.Right;

            if (sd.Gx > 200)
                ge = GesturesEnum.Up;
            if (sd.Gx < -200)
                ge = GesturesEnum.Down;

            if (sd.Gy > 200)
                ge = GesturesEnum.Clockwise;
            if (sd.Gy < -200)
                ge = GesturesEnum.CounterclockWise;

            if (ge == lastGestures)
                ge = GesturesEnum.None;
            else
                lastGestures = ge;
        
            return ge;
        }
    }
}
