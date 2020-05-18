using System;

namespace Core.Devices.Api.Models.Enum
{
    [Flags]
    public enum DeviceType
    {
        None = 0,
        Actuator = 1,
        Sensor = 2
    }
}