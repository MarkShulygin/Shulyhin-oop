
namespace lab_work_3
{
    public enum GameResult
    {
        Lose,
        Win
    }

    public abstract class AbstractGame
    {
        public GameAccount FirstUser { get; set; }
        public GameAccount SecondUser { get; set; }
        public int Rating { get; set; }
        public GameResult Result { get; set; }
        public int GameId { get; set; }

        public abstract int GetRating();

        public string GetInfo()
        {   
            return $"{FirstUser.GetInfo()}, {SecondUser.GetInfo()}, {Rating}, {Result}, {GameId}";
        }
    }
}
