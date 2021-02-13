using System;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount("Kingsley", 10000);

            Console.WriteLine($"Account {bankAccount.Number} was created for {bankAccount.Owner} with {bankAccount.Balance} balance");

            bankAccount.makeWithdrawal(2000, DateTime.Now, "Fish");
            Console.WriteLine(bankAccount.Balance);

            Console.WriteLine(bankAccount.GetAccountHistory());


            //try
            //{
            //    var invalidAccount = new BankAccount("Invalid User", -55); 
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
        }
    }
}
