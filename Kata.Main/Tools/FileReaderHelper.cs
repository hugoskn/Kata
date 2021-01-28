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

        public static int[] ReadFileAsInt(string path, string splitBy)
        {
            var lines = File.ReadLines(path);
            return lines.SelectMany(l => l.Split(splitBy)).Select(s => Convert.ToInt32(s)).ToArray();
        }
    }
}
