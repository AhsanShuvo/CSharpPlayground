using System;

namespace ConsoleApplication.BuilderPattern
{
	public class BankAccount
	{
		private long AccountNumber;
		private string Owner;
		private double Balance;

		public BankAccount(long accountNumber, string owner, double balance)
		{
			AccountNumber = accountNumber;
			Owner = owner;
			Balance = balance;
		}
	}
}

