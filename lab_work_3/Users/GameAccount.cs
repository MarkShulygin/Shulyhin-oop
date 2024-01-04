
namespace lab_work_3
{
    public class GameAccount
    {
        public GameAccount(string name)
        {
            Id = Id;
            UserName = name;
            CurrentRating = 1;
        }

        public int Id { get; set; }
        public string UserName { get; set; }

        private int currentRating;
        public int CurrentRating
        {
            get { return currentRating; }
            set
            {
                currentRating = value;
                if (currentRating < 0)
                {
                    currentRating = 0;
                }
            }
        }
        public int GamesCount
        {
            get
            {
                return GamesHistory.Count;
            }
        }

        public List<AbstractGame> GamesHistory = new();

        public virtual void WinGame(AbstractGame game)
        { 
            game.Result = GameResult.Win;
            game.GameId = GamesCount + 1;

            CurrentRating += game.Rating;

            GamesHistory.Add(game);
        }

        public virtual void LoseGame(AbstractGame game)
        { 
            game.Result = GameResult.Lose;
            game.GameId = GamesCount + 1;

            CurrentRating -= game.Rating;

            GamesHistory.Add(game);
        }

        public string GetInfo()
        {
            return $"{Id}. {UserName}";
        }
    }
}