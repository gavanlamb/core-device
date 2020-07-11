using Core.Device.Api.Models.Domain;
using DomainSize = Core.Device.Api.Models.Domain.Size;
using DtoSize = Core.Device.Api.Models.DTO.Size;

namespace Core.Device.Api.Mappers
{
    public static class SizeMapper
    {
        public static Size MapToDomain(
            Models.DTO.Size size)
        {
            return new Size
            {
                Height = size.Height,
                Width = size.Width
            };
        }
    }
}