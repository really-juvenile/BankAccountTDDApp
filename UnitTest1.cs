namespace BankAccountTDDApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIfDepositingPositiveAmount()
        {
            var depositAmount = 500;
            var expectedBalance = 500;

            BankAccount account = new BankAccount();
            account.Deposit(depositAmount);
            Assert.AreEqual(expectedBalance, account.GetBalance());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Deposit Amount must be positive")]
        public void TestIfDepositingNegativeAmount()
        {
            var depositAmount = -500;

            BankAccount account = new BankAccount();
            account.Deposit(depositAmount);
        }

        [TestMethod]
        public void TestValidWithdrawalAmount_Positive()
        {
            var initialDeposit = 1000;
            var withdrawalAmount = 200;
            var expectedBalance = 800;

            BankAccount account = new BankAccount();
            account.Deposit(initialDeposit);
            account.Withdraw(withdrawalAmount);
            Assert.AreEqual(expectedBalance, account.GetBalance());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Insufficient Funds")]
        public void TestWithdrawingMoreThanBalanceAmount()
        {
            var initialDeposit = 500;
            var withdrawalAmount = 50000;

            BankAccount account = new BankAccount();
            account.Deposit(initialDeposit);
            account.Withdraw(withdrawalAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Withdrawal amount must be positive")]
        public void TestWithdrawing_Negative_Amount()
        {
            var withdrawalAmount = -500;

            BankAccount account = new BankAccount();
            account.Withdraw(withdrawalAmount);
        }

        [TestMethod]
        public void TestingIfFundsAreGettingTransferred()
        {
            var depositAmount = 500;
            var transferAmount = 100;
            var expectedAccount1Balance = 400;
            var expectedAccount2Balance = 100;

            BankAccount account1 = new BankAccount();
            BankAccount account2 = new BankAccount();

            account1.Deposit(depositAmount);
            account1.Transfer(account2, transferAmount);

            Assert.AreEqual(expectedAccount1Balance, account1.GetBalance());
            Assert.AreEqual(expectedAccount2Balance, account2.GetBalance());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "The Account doesn't exist")]
        public void TestTransferringToAccount_Not_Exists()
        {
            var depositAmount = 1000;
            var transferAmount = 500;

            BankAccount account1 = new BankAccount();
            account1.Deposit(depositAmount);
            account1.Transfer(null, transferAmount);
        }
    }
}
