

namespace lab_work_3
{
    public class DoubleDeductionPointsGameAccount : GameAccount
    {
        public DoubleDeductionPointsGameAccount(string name) : base(name) { }

        public int LoseCounter { get; set; }

        public override void WinGame(AbstractGame game)
        {
            game.Result = GameResult.Win;
            game.GameId = GamesCount + 1;

            CurrentRating += game.Rating;

            LoseCounter = 0;

            GamesHistory.Add(game);
        }

        public override void LoseGame(AbstractGame game)
        {
            game.Result = GameResult.Lose;
            game.GameId = GamesCount + 1;

            LoseCounter++;

            if (LoseCounter > 2)
            {
                CurrentRating -= game.Rating * LoseCounter;
            }

            GamesHistory.Add(game);
        }
    }
}
