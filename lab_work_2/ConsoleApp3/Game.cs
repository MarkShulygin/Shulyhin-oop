 public class Game(string opponentName, bool isWinner, int rating, int gameIndex)  // Базовий клас гри
{
    public string OpponentName { get; } = opponentName;
    public bool IsWinner { get; } = isWinner;
    public int Rating { get; } = rating;
    public int GameIndex { get; } = gameIndex;
}