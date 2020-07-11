using System;

namespace Core.Device.Api.Models.Enum
{
    [Flags]
    public enum ThingType
    {
        None = 0,
        Actuator = 1,
        Sensor = 2
    }
}