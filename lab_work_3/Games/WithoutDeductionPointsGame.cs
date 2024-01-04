
namespace lab_work_3
{
    public class WithoutDeductionPointsGame : AbstractGame
    {
        public WithoutDeductionPointsGame()
        {
        }

        public WithoutDeductionPointsGame(GameAccount firstUserName, GameAccount secondUserName)
        {
            FirstUser = firstUserName;
            SecondUser = secondUserName;
            Rating = 0;
        }

        public override int GetRating()
        {
            return Rating;
        }
    }
}
