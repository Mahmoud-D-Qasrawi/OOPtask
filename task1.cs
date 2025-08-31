using System;
using System.Collections.Generic;
using static BankAPP.Bank;


namespace BankAPP
{
    public class Bank
    {
        private string _name { get; set; }
        private decimal _balance { get; set; }
        public string Name => _name;
        public decimal Balance => _balance;
        public static List<Bank> accounts = new List<Bank>();
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                Console.WriteLine($"Deposit was sucssesful \nYour balance now is {_balance}");
            }
        }
        public Bank(string name, decimal balance)
        {
            _name = name;
            if (balance >= 0)
                _balance = balance;
            else
                _balance = 0;
            accounts.Add(this);
        }
        public static void CreateAccount(string name, decimal balance = 0)
        {
            var newaccount = new Bank(name, balance);
        }
        public static bool FindAccount(string name)
        {
            var exist = accounts.Find(a => a._name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (exist != null)
            {
                Console.WriteLine("You already have an account");
                Console.WriteLine($"Your balance is {exist._balance}");
                return true;
            }
            else
            {
                CreateAccount(name);
                Console.WriteLine("A new account have been created");
                return false;
            }
        }
        public static Bank GetAccount(string name)
        {
            var exist = accounts.Find(a => a._name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return exist;
        }
    }
    internal class Program
    {
        static void Main()
        {
            //new Bank("Omar", 100);

            Console.WriteLine("Please enter your name");
            string name = Console.ReadLine();
            FindAccount(name);
            var Account = Bank.GetAccount(name);
            Console.WriteLine("Please enter the amount");
            decimal.TryParse(Console.ReadLine(), out decimal amount);
            Account.Deposit(amount);
        }
    }
}