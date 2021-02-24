using System;
using System.IO;
using System.Linq;

namespace Kata.Main.Tools
{
    public class FileReaderHelper
    {
        public static string[] ReadFile(string path, string splitBy)
        {
            var lines = File.ReadLines(path);
            return lines.SelectMany(l => l.Split(splitBy)).ToArray();
        }

        public static T[] ReadFile<T>(string path, string splitBy)
        {
            var lines = File.ReadLines(path);
            return lines.SelectMany(l => l.Split(splitBy).Select(s => (T)Convert.ChangeType(s, typeof(T)))).ToArray();
        }

        public static int[] ReadFileAsInt(string path, string splitBy)
        {
            var lines = File.ReadLines(path);
            return lines.SelectMany(l => l.Split(splitBy)).Select(s => Convert.ToInt32(s)).ToArray();
        }

        public static int[] ReadFileAsSingleLineInt(string path, string splitBy)
        {
            var lines = File.ReadLines(path).FirstOrDefault();
            var sArr = lines.Split(splitBy, StringSplitOptions.RemoveEmptyEntries);
            return sArr.Select(s => Convert.ToInt32(s)).ToArray();
        }
    }
}
