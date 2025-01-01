using EsSemplicePoliformismo;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Saving Account:");
        IBankAccount savingAccount = new SavingAccount();
        savingAccount.DepositAmout(2000);
        savingAccount.DepositAmout(1000);
        savingAccount.WithdrawAmount(1500);
        savingAccount.WithdrawAmount(5000);

        Console.WriteLine("\nCurren  Account:");
        IBankAccount currentAccount = new CurrentAccount();
        currentAccount.DepositAmout(500);
        currentAccount.DepositAmout(1500);
        currentAccount.WithdrawAmount(2600);
        currentAccount.WithdrawAmount(1000);
        Console.WriteLine($"Current Account Balance: {currentAccount.CheckBalance()}");
    }
}


/*
 * perchè uso il poliformismo con interfaccia?
 * 
 * Se in futuro dovessi modificare il comportamento comune a tutti i tipi di conti bancari, puoi aggiornare solo l'interfaccia e le relative implementazioni, senza dover toccare il codice che le utilizza.

Inoltre Puoi trattare oggetti di diversi tipi concreti (es. SavingAccount, CurrentAccount) nello stesso modo, purché implementino IBankAccount. Ad esempio:

List<IBankAccount> accounts = new List<IBankAccount>
{
    new SavingAccount(),
    new CurrentAccount()
};

foreach (var account in accounts)
{
    account.DepositAmout(1000);
}
*/