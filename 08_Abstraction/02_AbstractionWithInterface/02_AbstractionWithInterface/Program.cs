using System;
namespace GarbageCollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Transaction doing SBI Bank");
            IBank sbi = BankFactory.GetBankObject("SBI");   //ritorno oggetto di Sbi
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

    //in un interfaccia si possono solo dichiarare dei metodi
    //le 2 classi implementano IBank (percio tutti i suoi metodi)
    public interface IBank
    {
        void ValidateCard();
        void WithdrawMoney();
        void CheckBalanace();
        void BankTransfer();
        void MiniStatement();
    }

    //La factory è un design pattern che crea oggetti senza esporre la logica di creazione al chiamante. 
    //Ritornando un'interfaccia invece di una classe specifica il metodo permette di lavorare con qualsiasi 
    //implementazione di IBank senza preoccuparsi di quale classe concreta viene effettivamente utilizzata. (polif)
    public class BankFactory
    {
        public static IBank GetBankObject(string bankType)
        {
            IBank BankObject = null;
            if (bankType == "SBI")
            {
                BankObject = new SBI();     //assegno oggetto a reference di tipo interfaccia
            }
            else if (bankType == "AXIX")
            {
                BankObject = new AXIX();
            }
            return BankObject;      //ritorno oggetto SBI o AXIX
        }
    }

    public class SBI : IBank
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

    public class AXIX : IBank
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


/*
Analisi:

IBank bank = BankFactory.GetBankObject("SBI");
bank.ValidateCard();
In questo caso, l'oggetto ritornato è un'istanza della classe SBI, ma il chiamante può accedere solo ai metodi definiti nell'interfaccia IBank. Questo consente:

Di trattare tutti gli oggetti derivati da IBank nello stesso modo.
Di nascondere i dettagli dell'implementazione (incapsulamento).

Sì, la variabile bank è un reference all'oggetto effettivamente creato (come un'istanza di SBI o AXIX), e perciò può
accedere alle sue proprietà e ai suoi metodi, ma solo quelli definiti nell'interfaccia IBank.
*/