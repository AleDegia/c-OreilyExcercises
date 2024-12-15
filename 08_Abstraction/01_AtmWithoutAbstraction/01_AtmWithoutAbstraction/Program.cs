using System;
namespace GarbageCollectionDemo
{
    class AtmMachine
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Transaction doing SBI Bank");
            //lo user cliccando sulla classe può andare alla definizione e vedere l'implementazione -> no sicurezza
            SBI sbi = new SBI();
            sbi.ValidateCard();
            sbi.WithdrawMoney();
            sbi.CheckBalanace();
            sbi.BankTransfer();
            sbi.MiniStatement();

            Console.WriteLine("\nTransaction doing AXIX Bank");
            AXIX AXIX = new AXIX();
            AXIX.ValidateCard();
            AXIX.WithdrawMoney();
            AXIX.CheckBalanace();
            AXIX.BankTransfer();
            AXIX.MiniStatement();

            Console.Read();
        }
    }

    public class SBI    //banca 1
    {
        public void BankTransfer()
        {
            Console.WriteLine("SBI Bank Bank Transfer");
        }

        public void CheckBalanace()
        {
            Console.WriteLine("SBI Bank Check Balanace");
        }

        public void MiniStatement()
        {
            Console.WriteLine("SBI Bank Mini Statement");
        }

        public void ValidateCard()
        {
            Console.WriteLine("SBI Bank Validate Card");
        }

        public void WithdrawMoney()
        {
            Console.WriteLine("SBI Bank Withdraw Money");
        }
    }

    public class AXIX   //banca 2
    {
        public void BankTransfer()
        {
            Console.WriteLine("AXIX Bank Bank Transfer");
        }

        public void CheckBalanace()
        {
            Console.WriteLine("AXIX Bank Check Balanace");
        }

        public void MiniStatement()
        {
            Console.WriteLine("AXIX Bank Mini Statement");
        }

        public void ValidateCard()
        {
            Console.WriteLine("AXIX Bank Validate Card");
        }

        public void WithdrawMoney()
        {
            Console.WriteLine("AXIX Bank Withdraw Money");
        }
    }
}