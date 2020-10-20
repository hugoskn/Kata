using Newtonsoft.Json;
using System.IO;

namespace Kata.Main.Tools
{
    class JsonFileReader
    {
        public static T ReadJsonFile<T>(string path)
        {
            string json;
            using (var r = new StreamReader(path))
            {
                json = r.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(json);

        }
    }
}
