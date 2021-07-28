using Example.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class BankUnitTests
    {
        [TestMethod]
        public void TestDepositSuccess()
        {
            var bank = new Bank
            {
                Name = "Small Bank",
                Accounts = new List<Account>
            {
                new Account() { AccountId=1,  Owner = "Adam Smith", Description = "Checking", AcctType = AccountType.Checking, Balance = 500 }
            }
            };
            var bp = new Example.BankProcessing();
            var retVal = bp.Deposit(bank, 1, 50);
            Assert.AreEqual(retVal, 550.00);
        }

        [TestMethod]
        public void TestWithdrawlSuccess()
        {
            var bank = new Bank
            {
                Name = "Small Bank",
                Accounts = new List<Account>
            {
                new Account() { AccountId=1, Owner = "Adam Smith", Description = "Checking", AcctType = AccountType.Checking, Balance = 500 }
            }
            };
            var bp = new Example.BankProcessing();
            var retVal = bp.Withdrawl(bank, 1, 50);
            Assert.AreEqual(retVal, 450.00);
        }

        [TestMethod]
        public void TestWithdrawlFailure()
        {
            var bank = new Bank
            {
                Name = "Small Bank",
                Accounts = new List<Account>
            {
                new Account() { AccountId=1, Owner = "Adam Smith", Description = "Checking", AcctType = AccountType.Investment, Balance = 5 }
            }
            };
            var bp = new Example.BankProcessing();
            Assert.ThrowsException<ArgumentException>(() => bp.Withdrawl(bank, 1, 50));
        }

        [TestMethod]
        public void TestTransferSuccess()
        {
            var bank = new Bank
            {
                Name = "Transfering Bank, LLC",
                Accounts = new List<Account>
            {
                new Account() { AccountId = 1, Owner = "Adam Smith", Description = "Checking", AcctType = AccountType.Checking, Balance = 500.00 },
                new Account() { AccountId = 2, Owner = "Adam Smith", Description = "Individual Investment", AcctType = AccountType.Investment, InvestmentAcctType = InvestmentAccountType.Individual, Balance = 500.00 },
                new Account() { AccountId = 3, Owner = "Adam Smith", Description = "Corporate Investment", AcctType = AccountType.Investment, InvestmentAcctType = InvestmentAccountType.Corporate, Balance = 500.00 }
            }
            };
            var bp = new Example.BankProcessing();
            var retval = bp.Transfer(bank, 1, 2, 50.50);
            Assert.AreEqual(retval.Accounts.First(a => a.AccountId == 1).Balance, 449.50);
            Assert.AreEqual(retval.Accounts.First(a => a.AccountId == 2).Balance, 550.50);
            Assert.AreEqual(retval.Accounts.First(a => a.AccountId == 3).Balance, 500.00);
        }

    }
}
