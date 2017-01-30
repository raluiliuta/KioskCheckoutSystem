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
            try
            {
                var json = File.ReadAllText(pathToResource);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch(Exception e)
            {
                //TODO add logFile
                return default(T);   
            }            
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
                //TODO add logFile
                return null;
            }

            
        }
    }
}
