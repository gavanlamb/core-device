using System;

namespace Core.Device.Api.Models.Enum
{
    [Flags]
    public enum MessageProtocols
    {
        None = 0, 
        MQTT = 1
    }
}