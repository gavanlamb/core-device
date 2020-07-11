using System.Collections.Generic;

namespace Core.Device.Api.Models.DTO
{
    public class Image
    {
        public string Name { get; set; }

        public string Url { get; set; }
        
        public Size Size { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}