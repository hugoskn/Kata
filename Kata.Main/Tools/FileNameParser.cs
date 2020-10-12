using System.IO;

namespace Kata.Main.Tools
{
    class FileNameParser
    {
        public static void RenameFile(string pattern, string newName)
        {
            var d = new DirectoryInfo(@"C:\Users\HugoPonce\source\repos\SanahCbd\SanahCbd.Web\wwwroot\koi");
            var infos = d.GetFiles();
            foreach (var f in infos)
            {
                if (f.Name.Contains(pattern))
                {
                    File.Move(f.FullName, f.FullName.Replace(pattern, newName));
                }
                
            }

        }

    }
}
