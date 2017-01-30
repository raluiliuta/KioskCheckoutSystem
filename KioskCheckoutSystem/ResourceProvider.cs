using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KioskCheckoutSystem
{
    public static class ResourceProvider
    {
        public static T LoadJsonResource<T>(string pathToResource)
        {            
                var json = File.ReadAllText(pathToResource);
                return JsonConvert.DeserializeObject<T>(json);                        
        }

        public static List<string> ReadLinesFromFile(string pathToFile)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(pathToFile);
                return lines.ToList();
            }
            catch (Exception e)
            {                
                return null;
            }            
        }
    }
}
