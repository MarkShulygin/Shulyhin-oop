using System;

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
    public abstract void GetStats();
}


public class SimplePlayer : InheritPlayer
{
    public SimplePlayer(string userName, int initialRating) : base(userName, initialRating)
    {
    }

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

    public override void GetStats()
    {
        Console.WriteLine($"Stats for {UName}: Rating: {CurrentRating}, Games Played: {GamesCount}");
    }
}

public class ReducedRating : InheritPlayer
{
    public ReducedRating(string userName, int initialRating) : base(userName, initialRating)
    {
    }

    public override int WinGame(BaseGame game, string opponentName)
    {
        int points = game.CalculateRatingChange() / 2;
        Console.WriteLine($"{UName} won against {opponentName}. Rating: +{points}. Current Rating: {CurrentRating + points}");
        return points;
    }

    public override int LoseGame(BaseGame game)
    {
        int points = game.CalculateRatingChange() / 2;
        Console.WriteLine($"{UName} lost. Rating: -{points}. Current Rating: {CurrentRating - points}");
        return points;
    }

    public override void GetStats()
    {
        // Console.WriteLine($"Stats for {UserName}: Rating: {CurrentRating}, Games Played: {GamesCount}");
    }
}

public class StreakRating : InheritPlayer
{
    private int consecutiveWins;

    public StreakRating(string userName, int initialRating) : base(userName, initialRating)
    {
        consecutiveWins = 0;
    }

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
    
    public override void GetStats()
    {
        // Console.WriteLine($"Stats for {UserName}: Rating: {CurrentRating}, Games Played: {GamesCount}");
    }
}