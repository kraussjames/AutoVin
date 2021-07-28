using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Classes
{
    public enum AccountType
    {
        Checking,
        Investment
    }

    public enum InvestmentAccountType
    {
        Individual,
        Corporate
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawl,
        Transfer
    }

    public class Bank
    {
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
    }

    public class Account
    {
        public int AccountId { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public double Balance { get; set; }
        public AccountType AcctType { get; set; }
        public InvestmentAccountType InvestmentAcctType { get; set; }
    }

}
