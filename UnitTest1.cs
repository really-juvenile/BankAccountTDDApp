namespace BankAccountTDDApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIfDepositingPositiveAmount()
        {
            BankAccount account = new BankAccount();
            account.Deposit(500);
            Assert.AreEqual(500,account.GetBalance());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Deposit Amount must be positive")]
        public void TestIfDepositingNegativeAmount()
        {
            BankAccount account = new BankAccount();
            account.Deposit(-500);
        }

        [TestMethod]
        
        public void TestValidWithdrawalAmount_Positive()
        {
            BankAccount account = new BankAccount();
            account.Deposit(1000);
            account.Withdraw(200);
            Assert.AreEqual(800, account.GetBalance());
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Insufficient Funds")]
        public void TestWithdrawingMoreThanBalanceAmount()
        {
            BankAccount account = new BankAccount();
            account.Deposit(500);
            account.Withdraw(50000);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException), "Withdrawal amount must be positive")] 
        public void TestWithdrawing_Negative_Amount()
        {
            BankAccount account = new BankAccount();
            account.Withdraw(-500);
        }
        [TestMethod]
        public void TestingIfFundsAreGettingTransferred()
        {
            BankAccount account1 = new BankAccount();
            BankAccount account2 = new BankAccount();

            account1.Deposit(500);
            account1.Transfer(account2, 100);

            Assert.AreEqual(400, account1.GetBalance());
            Assert.AreEqual(100, account2.GetBalance());
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException),"The Account doesnt Exists")]
        public void TestTransferringToAccount_Not_Exists()
        {
            BankAccount account1 = new BankAccount();
            account1.Deposit(1000);
            account1.Transfer(null, 500);
        }

    }
}