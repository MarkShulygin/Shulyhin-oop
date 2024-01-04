
namespace lab_work_3
{
    public class DoublePointsGameAccount : GameAccount
    {

        public DoublePointsGameAccount(string name) : base(name) {}

        public int WinCounter { get; set; }

        public override void WinGame(AbstractGame game)
        {
            game.Result = GameResult.Win;
            game.GameId = GamesCount + 1;
            WinCounter++;
            if (WinCounter > 1)
            {
                CurrentRating += game.Rating * 2;
            }
            else
            {
                CurrentRating += game.Rating;
            }

            GamesHistory.Add(game);
        }

        public override void LoseGame(AbstractGame game)
        {
            game.Result = GameResult.Lose;
            game.GameId = GamesCount + 1;

            WinCounter = 0;

            CurrentRating -= game.Rating * 3;

            GamesHistory.Add(game);
        }
    }
}
