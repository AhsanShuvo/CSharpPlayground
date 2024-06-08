using System;

namespace ConsoleApplication.BuilderPattern
{
	public class BankAccountBuilder
	{
		private BankAccountV2 _bankAccount = new BankAccountV2();

		public BankAccountBuilder WithAccountNumber(long accountNumber)
		{
			_bankAccount.AccountNumber = accountNumber;
			return this;
		}

		public BankAccountBuilder WithOwner(string owner)
		{
			_bankAccount.Owner = owner;
			return this;
		}

		public BankAccountBuilder WithBalance(double balance)
		{
			_bankAccount.Balance = balance;
			return this;
		}

		public BankAccountBuilder WithBranch(string branch)
		{
			_bankAccount.Branch = branch;
			return this;
		}

		public BankAccountBuilder WithInterestRate(double interestRate)
		{
			_bankAccount.InterestRate = interestRate;
			return this;
		}

		public BankAccountV2 Build()
		{
			return _bankAccount;
		}
	}
}

