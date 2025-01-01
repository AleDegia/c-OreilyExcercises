using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsSemplicePoliformismo
{
    //è un account senza withdraw limit
    public class CurrentAccount : IBankAccount
    {
        private decimal Balance = 0;
        

        public bool DepositAmout(decimal amount)
        {
            Balance = Balance + amount;
            Console.WriteLine($"You have deposited: {amount}");
            Console.WriteLine($"Your account balance: {Balance}");
            return true;
        }

        public bool WithdrawAmount(decimal Amount)
        {
            if (Balance < Amount)
            {
                Console.WriteLine("Insufficent balance");
                return false;
            }
            
            else
            {
                Balance = Balance - Amount;
                Console.WriteLine($"You have successfully withdraw: {Amount}");
                Console.WriteLine($"Your account balance: {Balance}");
                return true;
            }
        }


        public decimal CheckBalance()
        {
            return Balance;
        }
    }
}
