using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Models
{
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