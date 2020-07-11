using Core.Device.Api.Models.Domain;
using DomainImage = Core.Device.Api.Models.Domain.Image;
using DtoImage = Core.Device.Api.Models.DTO.Image;

namespace Core.Device.Api.Mappers
{
    public class ImageMapper
    {
        public static Image MapToDomain(
            Models.DTO.Image image)
        {
            return new Image
            {
                Name = image.Name,
                Tags = image.Tags,
                Url = image.Url,
                Size = SizeMapper.MapToDomain(image.Size)
            };
        }
    }
}