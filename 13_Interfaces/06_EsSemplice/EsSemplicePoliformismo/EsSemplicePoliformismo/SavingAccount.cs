
namespace EsSemplicePoliformismo
{
    public class SavingAccount : IBankAccount
    {
        private decimal Balance = 0;
        private readonly decimal PerDayWithdrawLimit = 10000;
        private decimal TodayWithdrawal = 0;
        

        public bool DepositAmout(decimal amount)
        {
            Balance = Balance + amount;
            Console.WriteLine($"You have deposited: {amount}");
            Console.WriteLine($"Your account balance: {Balance}");
            return true;
        }

        //MAximum withdrawal per day: 10000
        public bool WithdrawAmount(decimal Amount)
        {
            if (Balance < Amount)
            {
                Console.WriteLine("Insufficent balance");
                return false;
            }
            else if (TodayWithdrawal + Amount > PerDayWithdrawLimit)
            {
                Console.WriteLine("Withdrwal attemp failed");
                return false;
            }
            else
            {
                Balance = Balance - Amount;
                TodayWithdrawal = TodayWithdrawal + Amount;
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
