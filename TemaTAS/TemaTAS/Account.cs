namespace TemaTAS
{
    public class Account
    {
        private float balance;
        private float minBalance = 10;

        public Account()
        {
            balance = 0;
        }

        public Account(int value)
        {
            balance = value;
        }

        public void Deposit(float amount)
        {
            if(amount >= 0)
                balance += amount;
            else throw new Exception();
        }

        public void Withdraw(float amount)
        {
            if (amount >= 0)
                balance -= amount;
            else throw new Exception();
        }

        public void TransferFunds(Account destination, float amount)
        {
            destination.Deposit(amount);    
            Withdraw(amount);
        }

        public Account TransferMinFunds(Account destination, float amount)
        {
            if (balance - amount > minBalance && amount >= 0)
            {
                destination.Deposit(amount);
                Withdraw(amount);
            }
            else throw new Exception();
            return destination;
        }

        public void TransferFundsFromEuroAmount(Account destination, float amount, ICurrencyConvertor euroRate)
        {
            float amountInRon = euroRate.ConvertFromEuroToRon(amount);
            if (balance - amountInRon > minBalance && amount >= 0)
            {
                destination.Deposit(amountInRon);
                Withdraw(amountInRon);
            }
            else throw new Exception();

        }

        public float Balance { get { return balance; } }    

        public float MinBalance { get { return minBalance; } }  
    }
}