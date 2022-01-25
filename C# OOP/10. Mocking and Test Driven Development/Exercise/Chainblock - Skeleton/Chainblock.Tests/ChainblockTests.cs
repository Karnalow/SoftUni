using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Chainblock.Tests
{
    public class ChainblockTests
    {
        private IChainblock chainblock;

        [SetUp]
        public void Setup()
        {
            chainblock = new Chainblock();
        }

        [Test]
        public void AddMethodShouldAddUniqueRecords()
        {
            ITransaction transaction = new Transaction();

            chainblock.Add(transaction);

            bool exist = chainblock.Contains(transaction);

            Assert.True(exist);
            Assert.AreEqual(1, chainblock.Count);
        }

        [Test]
        public void AddMethodMustAddOnlyUniqueTransactions()
        {
            ITransaction transaction = new Transaction
            {
                Id = 1245,
                From = "Ivan",
                To = "Hristo",
                Amount = 50,
                Status = TransactionStatus.Successfull
            };
            ITransaction dublicatedTransaction = new Transaction
            {
                Id = 1245,
                From = "Ivan",
                To = "Hristo",
                Amount = 50,
                Status = TransactionStatus.Successfull
            };

            chainblock.Add(transaction);
            chainblock.Add(dublicatedTransaction);

            bool transactionExist = chainblock.Contains(transaction);

            int expectedCount = 1;

            Assert.IsTrue(transactionExist);
            Assert.AreEqual(expectedCount, chainblock.Count);
        }

        [Test]
        public void ChangeTransactionStatusShouldChangeChangeTransactionStatus()
        {
            ITransaction transaction = new Transaction
            {
                Id = 85643,
                Status = TransactionStatus.Aborted,
                From = "Ivan",
                To = "Hristo",
                Amount = 100
            };

            chainblock.Add(transaction);

            chainblock.ChangeTransactionStatus(85643, TransactionStatus.Failed);

            ITransaction chainblockTransaction = chainblock.GetById(85643);

            Assert.AreEqual(TransactionStatus.Failed, chainblockTransaction.Status);
        }

        [Test]
        public void ChangeTransactionStatusShouldFieldWhenTransactionDoesNotExist()
        {
            ITransaction transaction = new Transaction
            {
                Id = 6325,
                Status = TransactionStatus.Successfull,
                From = "Ivan",
                To = "Hristo",
                Amount = 1000
            };

            chainblock.Add(transaction);

            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(3333, TransactionStatus.Unauthorized));
        }

        [Test]
        public void RemoveTransactionShouldRemoveTransactionIfExist()
        {
            ITransaction transaction = new Transaction
            {
                Id = 1,
                Status = TransactionStatus.Failed,
                From = "Ivan",
                To = "Hristo",
                Amount = 500
            };

            chainblock.Add(transaction);

            chainblock.RemoveTransactionById(1);

            bool exist = chainblock.Contains(1);

            Assert.AreEqual(0, chainblock.Count);
            Assert.IsFalse(exist);
        }

        [Test]
        public void RemoveTransactionShouldThrowExceptionIfTransactionDoesNotExist()
        {
            ITransaction transaction = new Transaction
            {
                Id = 1,
                Status = TransactionStatus.Failed,
                From = "Ivan",
                To = "Hristo",
                Amount = 500
            };

            chainblock.Add(transaction);

            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(15));
        }

        [Test]
        public void GetByIdShouldThrowExceptionIfInvalidIdIsPassed()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(123));
        }
    }
}
