using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Http.Headers;
using System.Security;
using System.Net.WebSockets;
namespace Lab5
{
    public class Student
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public List<int> Oceny { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WriteTextToFile();
            ReadTextFromFile();
            AddnewLines();
            SerializeStudents();
            DeserializeStudents();
            SerializeStudentsToXml();
            DeserializeStudentsFromXml();
            FileofCsv();
            FilterIrisCsv();

        }
        static void WriteTextToFile()
        {
            Console.WriteLine("How many lines you want for entering dates:");
            int line = int.Parse(Console.ReadLine());
            List<string> lines = new List<string>();
            for (int i = 0; i < line; i++)
            {
                Console.Write($"Enter lines {i + 1}");
                lines.Add(Console.ReadLine());
            }
            File.WriteAllLines("data.txt", lines);
            Console.WriteLine("Dane to add file");
        }
        static void ReadTextFromFile()
        {
            if (File.Exists("data.txt"))
            {
                string[] data = File.ReadAllLines("data.txt");
                foreach (string info in data)
                {
                    Console.WriteLine(info);
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }

        }
        static void AddnewLines()
        {
            Console.WriteLine("Add new lines to your file");
            int line = int.Parse(Console.ReadLine());
            List<string> lines = new List<string>();
            for (int i = 0; i < line; i++)
            {
                Console.WriteLine($"Enter line {i + 1}");
                lines.Add(Console.ReadLine());
            }
            File.AppendAllLines("data.txt", lines);
            Console.WriteLine("Dane to add file");
        }
        static void SerializeStudents()
        {
            List<Student> students = new List<Student>
            {
                new Student{ Imie = "Jan", Nazwisko = "Kowalski", Oceny = new List<int> {5, 4, 3} },
                new Student{ Imie = "Andrii", Nazwisko ="Kishchuk", Oceny = new List<int>{3, 5, 4} }
            };
            string jsonFile = JsonSerializer.Serialize(students);
            File.WriteAllText("students.json", jsonFile);
        }
        static void DeserializeStudents()
        {
            if (File.Exists("students.json"))
            {
                string readofFile = File.ReadAllText("students.json");
                var jsonFile = JsonSerializer.Deserialize<List<Student>>(readofFile);
                foreach (var student in jsonFile)
                {
                    Console.WriteLine($"Name: {student.Imie}, Surname: {student.Nazwisko}, Grates: {string.Join(", ", student.Oceny)}");
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }

        }
        static void SerializeStudentsToXml()
        {
            var students = new List<Student>
            {
                new Student { Imie = "Jan", Nazwisko = "Kowalski", Oceny = new List<int> { 5, 4, 3 } },
                new Student { Imie = "Andrii", Nazwisko = "Kishchuk", Oceny = new List<int> { 3, 5, 4 } }
            };
            var xmlFile = new System.Xml.Serialization.XmlSerializer(typeof(List<Student>));
            using (var fileStream = new StreamWriter("students.xml"))
            {
                xmlFile.Serialize(fileStream, students);
            }
        }
        static void DeserializeStudentsFromXml()
        {
            if (File.Exists("students.xml"))
            {
                var xmlfile_1 = new System.Xml.Serialization.XmlSerializer(typeof(List<Student>));
                using (var fileStream = new StreamReader("students.xml"))
                {
                    var students = (List<Student>)xmlfile_1.Deserialize(fileStream);
                    foreach (var student in students)
                    {
                        Console.WriteLine($"Name: {student.Imie}, Surname: {student.Nazwisko}, Grates: {string.Join(", ", student.Oceny)}");
                    }
                }
            }
        }
        static void FileofCsv()
        {
            if (!File.Exists("iris.csv"))
            {
                Console.WriteLine("File not found.");
                return;
            }
            else
            {
                foreach (var line in File.ReadAllLines("iris.csv"))
                {
                    Console.WriteLine(line);
                }
            }
            var lines = File.ReadAllLines("iris.csv");
            var headers = lines[0].Split(',');


            double[] sums = new double[headers.Length - 1];
            int count = 0;


            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                for (int j = 0; j < parts.Length - 1; j++)
                    if (double.TryParse(parts[j], out double value)) sums[j] = value;
                count++;
            }
            Console.WriteLine("Average value lines:");
            for (int i = 0; i < sums.Length; i++)
                Console.WriteLine($"{headers[i]} = {sums[i] / count}");
        }
        
        static void FilterIrisCsv()
        {
            if (!File.Exists("iris.csv"))
            {
                Console.WriteLine("File not found");
                return;
            }


            var lines = File.ReadAllLines("iris.csv");
            var header = lines[0].Split(',');


            int idxLength = Array.IndexOf(header, "sepal length");
            int idxWidth = Array.IndexOf(header, "sepal width");
            int idxClass = Array.IndexOf(header, "class");


            List<string> output = new List<string>();
            output.Add("sepal length,sepal width,class");


            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                if (double.TryParse(parts[idxLength],out double length))
                {
                    output.Add($"{parts[idxLength]},{parts[idxWidth]},{parts[idxClass]}");
                }
            }


            File.WriteAllLines("iris_filtered.csv", output);
            Console.WriteLine("Zapisano iris_filtered.csv");
        }

    }
}

