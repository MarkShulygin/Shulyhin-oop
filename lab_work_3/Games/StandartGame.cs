
namespace lab_work_3
{
    public class StandartGame : AbstractGame
    {
        public StandartGame()
        {
        }

        public StandartGame(GameAccount firstUserName,GameAccount secondUserName)
        {
            FirstUser = firstUserName;
            SecondUser = secondUserName;
            Rating = 1000;
        }

        public override int GetRating()
        {
            return Rating;  
        }
    }
}