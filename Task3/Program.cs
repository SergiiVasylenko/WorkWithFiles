using System;
using System.IO;

namespace Task3
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
                var deletedFilesSize = RemoveFiles(directory);
                var currentSize = CalculateSize(directory);
                Console.WriteLine($"Исходный размер папки {size}");
                Console.WriteLine($"Освобожденно {deletedFilesSize}");
                Console.WriteLine($"Текущий размер папки {currentSize}");

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

        public static long RemoveFiles(DirectoryInfo directory)
        {
            long size = 0;
            try
            {
                var files = directory.GetFiles();
                foreach (var file in files)
                {
                    size += file.Length;
                    file.Delete();
                }

                var directories = directory.GetDirectories();
                foreach (var dir in directories)
                {
                    size += RemoveFiles(dir);
                    dir.Delete(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erroe {ex.Message}");
            }
            return size;
        }
    }
}
