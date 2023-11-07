using System;
using System.Collections.Generic;
using System.Text;

namespace TemaTAS
{
    public class Tests
    {
        Account source;
        Account destination;

        [SetUp]
        public void Setup()
        {
            //arrange
            source = new Account();
            source.Deposit(200.00F);
            destination = new Account();
            destination.Deposit(150.00F);
        }

        [Test]
        [TestCase(200, 10)]
        [TestCase(200, 0)]
        [TestCase(200, -10)]
        public void Deposit(int initialDeposit, int depositAmount)
        {
            //arrange
            Account source = new Account();
            source.Deposit(initialDeposit);

            //act 
            source.Deposit(depositAmount);

            //assert
            Assert.That(source.Balance, Is.EqualTo(initialDeposit + depositAmount));
        }

        [Test]
        [TestCase(200, 10)]
        [TestCase(200, 0)]
        [TestCase(200, -10)]
        public void Withdraw(int initialDeposit, int withdrawAmount)
        {
            //arrange
            Account source = new Account();
            source.Deposit(initialDeposit);

            //act 
            source.Withdraw(withdrawAmount);

            //assert
            Assert.That(source.Balance, Is.EqualTo(initialDeposit - withdrawAmount));
        }



        [Test]
        [Category("pass")]
        public void TransferFunds()
        {
            //act
            source.TransferFunds(destination, 100.00F);

            //assert
            Assert.That(destination.Balance, Is.EqualTo(250.00F));
            Assert.AreEqual(100.00F, source.Balance);
        }

        [Test]
        [TestCase(200, 0, 78)]
        [TestCase(200, 0, 189)]
        [TestCase(200, 0, 1)]
        [TestCase(200, 0, 190)]
        [TestCase(200, 0, -10)]
        public void TransferMinFunds(int initialSourceBalance, int initialDestinationBalance, int transferAmount)
        {
            //arrange
            Account source = new Account();
            source.Deposit(initialSourceBalance);
            Account destination = new Account();
            destination.Deposit(initialDestinationBalance);

            //act
            source.TransferMinFunds(destination, transferAmount);

            //assert
            Assert.That(destination.Balance, Is.EqualTo(transferAmount));
            Assert.That(source.Balance, Is.EqualTo(initialSourceBalance - transferAmount));
        }

        [Test]
        [TestCase(200, 0, 10, 4.87F)]
        [TestCase(200, 150, 40, 5)]
        public void TransferFundsFromEuroAmount(int initialSourceBalance, int initialDestinationBalance, int euroAmount, float euroToRonRate)
        {
            //arrange
            Account source = new Account();
            source.Deposit(initialSourceBalance);
            Account destination = new Account();
            destination.Deposit(initialDestinationBalance);
            CurrencyConvertorStub converter = new CurrencyConvertorStub(euroToRonRate);

            //act
            source.TransferFundsFromEuroAmount(destination, euroAmount, converter);

            //assert
            float ronAmount = euroAmount * euroToRonRate;
            Assert.That(destination.Balance, Is.EqualTo(initialDestinationBalance + ronAmount));
            Assert.That(source.Balance, Is.EqualTo(initialSourceBalance - ronAmount));
        }

    }
}