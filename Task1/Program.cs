using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var folderPath = @"C:\Users\Sergii\Desktop\CleanFolder";
            if (Directory.Exists(folderPath))
            {
                var directory = new DirectoryInfo(folderPath);
                RemoveFiles(directory);
            }
            else
            {
                Console.WriteLine("Directory does not found!!!");
            }

            Console.ReadKey();
        }

        public static void RemoveFiles(DirectoryInfo directory)
        {
            try
            {
                var files = directory.GetFiles();
                foreach (var file in files)
                {
                    if (DateTime.Now.Subtract(file.LastAccessTime) > TimeSpan.FromMinutes(30))
                    {
                        file.Delete();
                    }
                }

                var directories = directory.GetDirectories();
                foreach (var dir in directories)
                {
                    RemoveFiles(dir);
                    if (DateTime.Now.Subtract(dir.LastAccessTime) > TimeSpan.FromMinutes(30))
                    {
                        dir.Delete(false);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erroe {ex.Message}");
            }
        }
    }
}
