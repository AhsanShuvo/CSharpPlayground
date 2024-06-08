using System;
namespace ConsoleApplication.BuilderPattern
{
	public class BankAccountV2
	{
        public long AccountNumber { get; set; }
        public string Owner { get; set; }
        public double Balance { get; set; }
        public string Branch { get; set; }
        public double InterestRate { get; set; }
    }
}

