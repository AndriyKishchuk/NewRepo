using System;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Account account = new Account("John Doe", 1000.00m);
        Account account2 = new Account("Jane Smith", 500.00m);

        account.Deposit(250.00m);
        Console.WriteLine($"Account Name: {account.Name}, Balance: {account.Balance:C}");
        account2.Withdraw(100.00m);
        Console.WriteLine($"Account Name: {account2.Name}, Balance: {account2.Balance:C}");
    }
}
class Account
{
    public  string? Name { get; set; }
    public  decimal Balance { get; set; }

    public Account(string name, decimal Balance)
    {
        this.Balance = Balance;
        this.Name = name;
    }
    public void DisplayAccountInfo()
    {
        Console.WriteLine($"Account Name: {Name}, Balance: {Balance:C}");
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited: {amount:C}. New Balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive.");
        }
    }
    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdraw: {amount:C}. New Balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Insufficient funds or invalid amount.");
        }
    }
}