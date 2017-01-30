using Newtonsoft.Json;
using System.IO;

namespace KioskCheckoutSystem
{
    public static class ResourceProvider
    {
        public static T loadJsonResource<T>(string pathToResource)
        {
            var json = File.ReadAllText(pathToResource);
            var values = JsonConvert.DeserializeObject<T>(json);

            return values;
        }
    }
}
