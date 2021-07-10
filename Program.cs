using System;
using classes;

namespace bank_with_POO
{
  class Program
  {
    static void Main(string[] args)
    {
      var account = new BankAccount("facelessvoid", 1000);
      System.Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
    }
  }
}

