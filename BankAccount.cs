using System;
using System.Collections.Generic;

namespace classes
{
	public class BankAccount
	{
		private static int accountNumberSeed = 1234567890;
		public string Number { get; }
		public string Owner { get; }
		public decimal Balance
		{
			get
			{
				decimal balance = 0;
				foreach (var transaction in allTransactions)
				{
					balance += transaction.Amount;
				}
				return balance;
			}

		}
		public BankAccount(string name, decimal initialBalance)
		{
			this.Owner = name;
			this.Number = accountNumberSeed.ToString();
			accountNumberSeed++;
			MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
		}

		private List<Transaction> allTransactions = new List<Transaction>();

		public void MakeDeposit(decimal amount, DateTime date, string note)
		{
			if (amount <= 0)
				throw new ArgumentOutOfRangeException(
					nameof(amount), "Amount of deposit must be positice");

			var deposit = new Transaction(amount, date, note);
			allTransactions.Add(deposit);
		}

		public void MakeWithdrawal(decimal amount, DateTime date, string note)
		{
			if (amount <= 0)
				throw new ArgumentOutOfRangeException(
					nameof(amount), "Amount of withdrawal must be positive");

			if (Balance - amount < 0)
				throw new InvalidOperationException(
					"Not sufficient funds for this withdrawal");

			var withdrawal = new Transaction(-amount, date, note);
			allTransactions.Add(withdrawal);
		}

		public string GetAccountHistory()
		{
			var report = new System.Text.StringBuilder();
			decimal balance = 0;

			report.AppendLine("Date\t\tAmount\tBalance\tNote");
			foreach (var transaction in allTransactions)
			{
				balance += transaction.Amount;
				report.AppendLine(
					$"{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t{balance}\t{transaction.Notes}");
			}

			return report.ToString();
		}
	}
}