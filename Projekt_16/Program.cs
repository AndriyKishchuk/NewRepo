using System;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter number: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int number))
            {
                Console.WriteLine($"The number is {number}");
            }
            else
            {
                throw new FormatException("Input was not a valid integer.");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");

        }

    }
}