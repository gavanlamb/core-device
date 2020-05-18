using DTO = Core.Devices.Api.Models.DTO;
using Domain = Core.Devices.Api.Models.Domain;

namespace Core.Devices.Api.Mappers
{
    public static class UserDeviceMapper
    {
        public static DTO.UserDevice MapToDto(
            Domain.UserDevice userDevice)
        {
            return new DTO.UserDevice
            {
                Id = userDevice.Id.ToString(),
                Name = userDevice.Name,
                Types = userDevice.Types
            };
        }
    }
}