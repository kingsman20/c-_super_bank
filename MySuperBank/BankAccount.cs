using System;
using System.Collections.Generic;
using System.Text;

namespace MySuperBank
{
    public class BankAccount
    {
        public string Number { get; }

        public string  Owner { get; set; }

        public decimal Balance { get {
                decimal balance = 0;
                foreach (var item in transactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        private static int accountSeed = 1234567890;

        private List<Transaction> transactions = new List<Transaction>();

        public BankAccount(string owner, decimal balance)
        {
            Owner = owner;
            MakeDeposit(balance, DateTime.Now, "Initial Deposit");
            this.Number = accountSeed.ToString();
            accountSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }

            var deposit = new Transaction(amount, date, note);
            transactions.Add(deposit);
        }

        public void makeWithdrawal(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }

            if(Balance - amount < 0)
            {
                throw new InvalidOperationException("No sufficient funds for this withdrawal");
            }

            var withdrawal = new Transaction(-amount, date, note);
            transactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            report.AppendLine("Date\t\t\tAmount\tNote");

            foreach (var item in transactions)
            {
                report.AppendLine($"{item.Date}\t{item.Amount}\t{item.Notes}");
            }

            return report.ToString();
        }


    }
}
