using System;
using System.Collections.Generic;

public class GameAccount(InheritPlayer player)
{
    public InheritPlayer Player { get; set; } = player;
    private List<Game> gamesHistory = [];

    public void WinGame(InheritPlayer opponent, BaseGame game)
    {
        int ratingChange = Player.WinGame(game, Player.UName);
        Player.CurrentRating += ratingChange;
        Player.GamesCount++;
        gamesHistory.Add(new Game(Player.UName, true, ratingChange, Player.GamesCount));
    }

    public void LoseGame(InheritPlayer opponent, BaseGame game)
    {
        int ratingChange = Player.LoseGame(game);
        Player.CurrentRating = Math.Max(1, Player.CurrentRating - ratingChange);
        Player.GamesCount++;
        gamesHistory.Add(new Game(opponent.UName, false, ratingChange, Player.GamesCount));
    }

    public void GetStats()
    {
        Console.WriteLine($"Game history for {Player.UName}:");
        Console.WriteLine("Opponent\tGame\tOutcome Rating\t\tIndex");

        foreach (var game in gamesHistory)
        {
            Console.WriteLine($"{game.OpponentName}\t\t{(game.IsWinner ? "Win" : "Loss")}\t\t{(game.IsWinner ? "+" : "-") + game.Rating}\t\t{game.GameIndex}");
        }
    }
}