using System;

namespace classes
{
  public class BankAccount
  {
    private static int accountNumberSeed = 1234567890;
    public string Number { get; }
    public string Owner { get; }
    public decimal Balance { get; }
    public BankAccount(string name, decimal initialBalance)
    {
      this.Owner = name;
      this.Balance = initialBalance;
      this.Number = accountNumberSeed.ToString();
      accountNumberSeed++;
    }

    public void MakeDeposit(decimal amount, DateTime data, string note)
    {
      var account = new BankAccount("<name>", 1000);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {

    }
  }
}