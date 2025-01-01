using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsSemplicePoliformismo
{
    internal interface IBankAccount
    {
        bool DepositAmout(decimal amount);
        bool WithdrawAmount(decimal amount);
        decimal CheckBalance();
    }
}
