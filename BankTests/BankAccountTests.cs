using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");

        }
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
            account.Debit(debitAmount));
        }
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange

            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 10.0;
            double creditAmount = -1.0;
            BankAccount account = new BankAccount("Mr. John Doe", beginningBalance);

            // Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                account.Credit(creditAmount));
        }
        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 10.0;
            double creditAmount = 5.0;
            double expected = 15.0;
            BankAccount account = new BankAccount("Mr. John Doe", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 15.0, "Account not credited correctly");
        }
        [TestMethod]
        public void Debit_WithZeroAmount_DoesNotChangeBalance()
        {
            // Arrange
            double beginningBalance = 10.0;
            double debitAmount = 0.0;
            double expected = beginningBalance;
            BankAccount account = new BankAccount("Mr. John Doe", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Balance should not change when debiting zero");
        }
    }
}
