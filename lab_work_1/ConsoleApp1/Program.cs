using lab1;


Random rnd = new Random(); // В майбутньому буде використана для визначення скільки рейтингу забрати чи видати 


var account = new GameAccount("Mark Shulyhin TR-24", rnd.Next(0,100)); // Створюємо аккаунт з випадково визначеним рейтнгом


Console.WriteLine(account.UserName);
account.WinGame(rnd.Next(25,30), DateTime.Now, "Win");
account.WinGame(rnd.Next(25,30), DateTime.Now, "Win");
account.LoseGame(rnd.Next(25,30), DateTime.Now, "Lose");
Console.WriteLine(account.GetAccountHistory()); // Виводить історію аккаунта
// Console.WriteLine(account.accountNumberSeed);


namespace lab1 //Місце праці
{
    public class Game // публічний класс Game
    {
        public int Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }
        public Game(int amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Notes = note;
        }
    }


    public class GameAccount // публічний класс GameAccount
    {
        private List<Game> allGames = new List<Game>(); // список з ігор взятий з классу Game
        public string UserName { get; set; } // Нікнейм гравця
        public string RatingChange { get; } // Зміна рейтингу
        public int CurrentRating  // 
        { 
            get
            {
                int rating = 0;
                foreach (var item in allGames)
                {
                    rating += item.Amount;
                }
                return rating;
            }
        }


        public int GamesCount { get; }
        static int accountNumberSeed = 1234567890;
        public GameAccount(string name, int initialRating)
        {
            RatingChange = accountNumberSeed.ToString();
            accountNumberSeed++;
            Console.WriteLine(accountNumberSeed);

            UserName = name;
            WinGame(initialRating, DateTime.Now, "Initial balance");
        }


        public void WinGame(int amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "can give only positive rating");
            }
            var winRating = new Game(amount, date, note);
            allGames.Add(winRating);
        }


        public void LoseGame(int amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "can give only positive rating");
            }
            var loseRating = new Game(-amount, date, note);
            allGames.Add(loseRating);
        }


        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            int rating = 0;
            report.AppendLine("Date\t\tRatingChange\tRaiting\tNote");
            foreach (var item in allGames)
            {
                rating += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{rating}\t{item.Notes}");
            }
            return report.ToString();
        }
    }
}