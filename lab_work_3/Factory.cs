
namespace lab_work_3
{
    internal class Factory
    {
        public AbstractGame CreateStandartGame(GameAccount firstUserName, GameAccount secondUserName)
        {
            StandartGame game = new(firstUserName, secondUserName);
            AbstractGame newGame = game;
            return newGame;
        }

        public AbstractGame CreateWithoutDeductionPointsGame(GameAccount firstUserName, GameAccount secondUserName)
        {
            WithoutDeductionPointsGame game = new(firstUserName, secondUserName);
            return game;
        }
    }
}
