using System;

namespace classes
{
  public class LineOfCreditAccount : BankAccount
  {
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit) { }

    public override void PerformMonthEndTransactions()
    {
      if (Balance < 0)
      {
        var interest = -Balance * 0.07m;
        MakeWithdrawal(interest, System.DateTime.Now, "Charge monthly interest");
      }
    }
    protected override Transaction CheckWithdrawalLimit(bool isOverdrawn)
      => isOverdrawn ?
        new Transaction(-20, DateTime.Now, "Apply overdraft fee")
        : default;
  }
}