﻿using System;
namespace GarbageCollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Transaction doing SBI Bank");
            IBank sbi = BankFactory.GetBankObject("SBI");
            sbi.ValidateCard();
            sbi.WithdrawMoney();
            sbi.CheckBalanace();
            sbi.BankTransfer();
            sbi.MiniStatement();

            Console.WriteLine("\nTransaction doing AXIX Bank");
            IBank AXIX = BankFactory.GetBankObject("AXIX");
            AXIX.ValidateCard();
            AXIX.WithdrawMoney();
            AXIX.CheckBalanace();
            AXIX.BankTransfer();
            AXIX.MiniStatement();

            Console.Read();
        }
    }

    public abstract class IBank
    {
        public abstract void ValidateCard();
        public abstract void WithdrawMoney();
        public abstract void CheckBalanace();
        public abstract void BankTransfer();
        public abstract void MiniStatement();
    }

    public class BankFactory
    {
        public static IBank GetBankObject(string bankType)
        {
            IBank BankObject = null;
            if (bankType == "SBI")
            {
                BankObject = new SBI();
            }
            else if (bankType == "AXIX")
            {
                BankObject = new AXIX();
            }
            return BankObject;
        }
    }

    public class SBI : IBank
    {
        public override void BankTransfer()
        {
            Console.WriteLine("SBI Bank Bank Transfer");
        }

        public override void CheckBalanace()
        {
            Console.WriteLine("SBI Bank Check Balanace");
        }

        public override void MiniStatement()
        {
            Console.WriteLine("SBI Bank Mini Statement");
        }

        public override void ValidateCard()
        {
            Console.WriteLine("SBI Bank Validate Card");
        }

        public override void WithdrawMoney()
        {
            Console.WriteLine("SBI Bank Withdraw Money");
        }
    }

    public class AXIX : IBank
    {
        public override void BankTransfer()
        {
            Console.WriteLine("AXIX Bank Bank Transfer");
        }

        public override void CheckBalanace()
        {
            Console.WriteLine("AXIX Bank Check Balanace");
        }

        public override void MiniStatement()
        {
            Console.WriteLine("AXIX Bank Mini Statement");
        }

        public override void ValidateCard()
        {
            Console.WriteLine("AXIX Bank Validate Card");
        }

        public override void WithdrawMoney()
        {
            Console.WriteLine("AXIX Bank Withdraw Money");
        }
    }
}


/*
 I metodi definiti nella classe abstract devono possono avere il modificatore abstract. 
Se lo hanno non devono avere un'implementazione.
Ogni classe derivata concreta (non astratta) deve fornire l'override di questi metodi.

Se l'abstract class contiene metodi non astratti (metodi con un'implementazione), la classe derivata non è obbligata a fare override di questi metodi. 

*/