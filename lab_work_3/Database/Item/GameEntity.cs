
namespace lab_work_3
{
    public enum GameType
    {
        StandartGame,
        WithoutDeductionPointsGame
    };
    public class GameEntity
	{
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }
        public int Rating { get; set; }
        public GameResult Result { get; set; }
        public int GameId { get; set; }
        public GameType Type { get; set; }
    }
}

