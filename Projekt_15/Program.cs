using System;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter number for divided: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int divided))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                return;
            }
            Console.WriteLine("Enter number for divided:");
            string input2 = Console.ReadLine();
            if (!int.TryParse(input2, out int divisor))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                return;
            }
            decimal result = (decimal)divided / divisor;
            Console.WriteLine("Result: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}