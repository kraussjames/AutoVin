using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Classes;

namespace Example
{
    public class BankProcessing
    {
        public double Deposit(Bank bank, int accountId, double amount)
        {
            if (amount<=0)
            {
                throw new ArgumentException("Deposit amount must be a positive number.");
            }
            var acct = bank.Accounts.First(a => a.AccountId == accountId);
            acct.Balance += amount;
            //TODO: Save to Data Repository
            return acct.Balance;
        }

        public double Withdrawl(Bank bank, int accountId, double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawl amount must be a positive number.");
            }
            else
            {
                var acct = bank.Accounts.First(a => a.AccountId == accountId);
                if (acct.Balance < amount || acct.AcctType == AccountType.Investment && acct.InvestmentAcctType == InvestmentAccountType.Individual && amount > 500)
                {
                    if (acct.Balance < amount)
                    {
                        throw new ArgumentException("Withdrawl Amount Exceeds available balance");
                    }
                    throw new ArgumentException("Individual Accounts have a withdrawl limit of $500");
                }
                acct.Balance -= amount;
                //TODO: Save to Data Repository
                return acct.Balance;
            }
        }

        public Bank Transfer(Bank bank, int sourceAccountId, int targetAccountId, double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Transfer amount must be a positive number.");
            }
            try
            {
                bank.Accounts.First(a => a.AccountId == sourceAccountId).Balance -= amount;
                bank.Accounts.First(a => a.AccountId == targetAccountId).Balance += amount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bank;
        }
    }
}
