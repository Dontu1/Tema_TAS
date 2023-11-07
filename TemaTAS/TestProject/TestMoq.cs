using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using System.Xml;
using System.Linq;
using NUnit.Framework;

namespace TemaTAS
{
    public class TestMoq
    {
        [SetUp]
        public void InitAccount()
        {
            //arrange
        }

        [Test]
        [TestCase(200, 0, 10, 4.87F)]
        public void TransferFundsFromEuroAmount(int initialSourceBalance, int initialDestinationBalance, int euroAmount, float euroToRonRate)
        {
            //arrange the MockObject
            var mockConverter = new Moq.Mock<ICurrencyConvertor>();

            //arrange 
            Account source = new Account();
            source.Deposit(initialSourceBalance);
            Account destination = new Account();
            destination.Deposit(initialDestinationBalance);

            //Set mock convertor
            mockConverter.Setup(x => x.ConvertFromEuroToRon(It.IsAny<float>())).Returns((float amount) => amount * euroToRonRate);

            //act
            source.TransferFundsFromEuroAmount(destination, euroAmount, mockConverter.Object);

            //assert
            float ronAmount = euroAmount * euroToRonRate;
            Assert.That(destination.Balance, Is.EqualTo(ronAmount));
            Assert.That(source.Balance, Is.EqualTo(initialSourceBalance - ronAmount));

            //mock object verify
            mockConverter.Verify(x => x.ConvertFromEuroToRon(It.IsAny<float>()), Times.Once());
        }


    }
}
