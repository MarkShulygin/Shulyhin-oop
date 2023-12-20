using lab1;

var account = new BankAccount("<name>", 1000);

account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
// Console.WriteLine(account.Balance);
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
// Console.WriteLine(account.Balance);
Console.WriteLine(account.GetAccountHistory());

BankAccount invalidAccount;
try
{
    invalidAccount = new BankAccount("invalid", -1);
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine("Exeption caught creating account with negative balance");
    // Console.WriteLine(e.ToString());
    return;
}


namespace lab1
{
    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }
        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Notes = note;
        }
    }

    public class BankAccount
    {
        private List<Transaction> allTransactions = new List<Transaction>();
        public string Number{ get; }
        public string Owner { get; set; }
        public decimal Balance 
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }        
        private static int accountNumberSeed = 1234567890;
        
        public void MakeDeposit(decimal amount, DateTime date, string note) 
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }
        public BankAccount(string name, decimal initialBalance)
        {
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }
        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }
    }
}