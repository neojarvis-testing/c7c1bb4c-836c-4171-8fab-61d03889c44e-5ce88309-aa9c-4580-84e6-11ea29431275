using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonLibrary.Models
{
    public static class Enums
    {
        public static bool IsValidEnumValue<T>(this string text) where T : struct
        {
            if(!string.IsNullOrEmpty(text))
            {
                T tempValue;
                if(Enum.TryParse(text, out tempValue))
                {
                    return true;
                }
            }
            
            return false;
        }
    }
    
    public enum UserRoleEnum
    {
        Customer,
        Teller,
        Manager
    }

    public enum AccountTypeEnum
    {
        Savings,
        Current
    }

    public enum AccountStatusEnum
    {
        Pending,
        Active,
        Deactivated
    }

    public enum TransactionTypeEnum
    {
        Deposit,
        Withdrawal,
        Transfer
    }

    public enum TransactionStatusEnum
    {
        Pending,
        Completed,
        Failed
    }

    public enum DepositStatusEnum
    {
        Active,
        Closed,
        ClosedPrematuarely
    }
}