using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var folderPath = @"C:\Users\Sergii\Desktop\MyFolder";
            if (Directory.Exists(folderPath))
            {
                var directory = new DirectoryInfo(folderPath);
                var size = CalculateSize(directory);
                Console.WriteLine($"Size folder is {size}");
            }
            else
            {
                Console.WriteLine("Directory does not found!!!");
            }

            Console.ReadKey();
        }

        public static long CalculateSize(DirectoryInfo directory)
        {
            long size = 0;
            try
            {
                var files = directory.GetFiles();
                foreach (var file in files)
                {
                    size += file.Length;
                }

                var directories = directory.GetDirectories();
                foreach (var dir in directories)
                {
                    size += CalculateSize(dir);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
            return size;
        }
    }
}
