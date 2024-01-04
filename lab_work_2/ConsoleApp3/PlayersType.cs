//Створення базового класу гравця для наслідування
public abstract class InheritPlayer
{
    public string UName { get; protected set; }
    public int CurrentRating { get; set; } // Зроблено set публічним
    public int GamesCount { get; set; }    // Зроблено set публічним

    public InheritPlayer(string userName, int initialRating)
    {
        UName = userName;
        CurrentRating = initialRating;
        GamesCount = 0;
    }

    public abstract int WinGame(BaseGame game, string opponentName);
    public abstract int LoseGame(BaseGame game);

}

// Звичайний гравець з прописаними для нього Win та Lose
public class SimplePlayer(string userName, int initialRating) : InheritPlayer(userName, initialRating)
{
    public override int WinGame(BaseGame game, string opponentName)
    {
        int points = game.CalculateRatingChange();
        Console.WriteLine($"{UName} won against {opponentName}. Rating: +{points}. Current Rating: {CurrentRating + points}");
        return points;
    }

    public override int LoseGame(BaseGame game)
    {
        int points = game.CalculateRatingChange();
        Console.WriteLine($"{UName} lost. Rating: -{points}. Current Rating: {CurrentRating - points}");
        return points;
    }
}

// Граець зі зменшеним покаранням та прописаними для нього Win та Lose
public class ReducedRating(string userName, int initialRating) : InheritPlayer(userName, initialRating)
{
    public override int WinGame(BaseGame game, string opponentName)
    {
        int points = game.CalculateRatingChange();
        Console.WriteLine($"{UName} won against {opponentName}. Rating: +{points}. Current Rating: {CurrentRating + points}");
        return points;
    }

    public override int LoseGame(BaseGame game)
    {
        int points = game.CalculateRatingChange() / 2;
        Console.WriteLine($"{UName} lost. Rating: -{points}. Current Rating: {CurrentRating - points}");
        return points;
    }
}

// Гравець який має переможний стрік та з прописаними для нього Win та Lose
public class StreakRating(string userName, int initialRating) : InheritPlayer(userName, initialRating)
{
    private int consecutiveWins = 0;

    public override int WinGame(BaseGame game, string opponentName)
    {
        int points = game.CalculateRatingChange();
        consecutiveWins++;
        if (consecutiveWins >= 3)
        {
            points += 10;
        }
        Console.WriteLine($"{UName} won against {opponentName}. Rating: +{points}. Current Rating: {CurrentRating + points}");
        return points;
    }

    public override int LoseGame(BaseGame game)
    {
        int points = game.CalculateRatingChange();
        consecutiveWins = 0;
        Console.WriteLine($"{UName} lost. Rating: -{points}. Current Rating: {CurrentRating - points}");
        return points;
    }
}