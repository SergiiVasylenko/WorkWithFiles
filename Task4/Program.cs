using FinalTask;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var folderPath = @"C:\Users\Sergii\Desktop\Students";

            IEnumerable<Student> students;
            using (var fs = new FileStream(@"C:\Users\Sergii\Desktop\Students.dat", FileMode.OpenOrCreate))
            {
                var formatter = new BinaryFormatter();
                students = (IEnumerable<Student>)formatter.Deserialize(fs);  
            }

            var directory = new DirectoryInfo(folderPath);
            directory.Create();

            var dictionary = new Dictionary<string, List<string>>();
            foreach (var student in students)
            {
                if (dictionary.ContainsKey(student.Group))
                {
                    dictionary[student.Group].Add($"{student.Name}, {student.DateOfBirth}");
                }
                else
                {
                    dictionary.Add(student.Group, new List<string> { $"{student.Name}, {student.DateOfBirth}" });
                }
            }

            foreach (var item in dictionary)
            {
                using (StreamWriter sw = File.CreateText($"{directory.FullName}/{item.Key}"))
                {
                    foreach (var value in item.Value)
                    {
                        sw.WriteLine(value);
                    }
                }
            }
        }
    }
}
