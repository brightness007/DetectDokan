using Pastel;
using System;
using System.Drawing;
using System.IO;

namespace DetectDokan
{
    class Program
    {
        // https://stackoverflow.com/questions/336633/how-to-detect-windows-64-bit-platform-with-net
        static void Main(string[] args)
        {
            bool isWow64Process = false;
            bool is64BitOperatingSystem = PlatformUtility.Is64BitOperatingSystem(out isWow64Process);

            string path = Environment.ExpandEnvironmentVariables(
                isWow64Process ? @"%windir%\Sysnative\drivers\dokan1.sys" : @"%windir%\System32\drivers\dokan1.sys");

            Console.WriteLine($" Operation System = {(is64BitOperatingSystem ? "64-bit" : "32-bit").Pastel(Color.Cyan)}");
            if (is64BitOperatingSystem)
            {
                Console.WriteLine($" Is Wow64 Process = {isWow64Process.ToString().Pastel(Color.Cyan)}");
            }
            Console.WriteLine($"Dokan Driver File = {(File.Exists(path) ? "Found".Pastel(Color.Cyan) : "Not Found".Pastel(Color.Yellow))}");
            Console.WriteLine();
            Console.WriteLine($"    {path}");
            Console.WriteLine();

            if (DokanDriverUtility.QueryVersion(out var version))
            {
                Console.WriteLine($"   Driver Version = {version.ToString("x").Pastel(Color.Cyan)}");
            }
            else
            {
                Console.WriteLine($"   Driver Version = {"Unknown".Pastel(Color.Yellow)}");
            }
        }
    }
}
