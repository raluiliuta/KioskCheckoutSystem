using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskCheckoutSystem
{
    public static class ResourceProvider
    {
        public static T loadJsonResource <T>( string pathToResource )
        {
            var json = File.ReadAllText(pathToResource);
            var values = JsonConvert.DeserializeObject<T>(json);

            return values;
        }
    }
}
