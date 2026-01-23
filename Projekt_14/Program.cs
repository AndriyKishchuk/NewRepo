using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Введіть шлях до файлу: ");
        string filePath = Console.ReadLine();

        Console.WriteLine("Введіть шлях до файлу, в який потрібно скопіювати дані:");
        string copyFilePath = Console.ReadLine();

        File.Copy(filePath, copyFilePath,true);

        Console.WriteLine("Файл успішно скопійовано");
    }
}