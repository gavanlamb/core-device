using System.Collections.Generic;
using System.Linq;

namespace Core.Device.Api.Extensions
{
    public static class LinqHelpers
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }
    }
}