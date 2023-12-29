﻿class Program
{
    static void Main()
    {
        InheritPlayer player1 = new SimplePlayer("player1", 2350);
        InheritPlayer player2 = new ReducedRating("player2", 1270);
        InheritPlayer player3 = new StreakRating("Player3", 500);

        GameFactory gameFactory = new GameFactory();

        BaseGame standardGame = gameFactory.CreateGame("Standard");
        BaseGame trainingGame = gameFactory.CreateGame("Training");
        BaseGame singlePlayerGame = gameFactory.CreateGame("SinglePlayer");

        GameAccount gameAccount1 = new(player1);
        GameAccount gameAccount2 = new(player2);
        GameAccount gameAccount3 = new(player3);

        gameAccount1.WinGame(player2, standardGame);
        gameAccount2.LoseGame(player1, standardGame);

        Console.WriteLine("\n");

        gameAccount1.WinGame(player2, trainingGame);
        gameAccount2.LoseGame(player1, trainingGame);


        Console.WriteLine("\n");

        gameAccount3.WinGame(player3, singlePlayerGame);
        gameAccount3.WinGame(player3, singlePlayerGame);
        gameAccount3.WinGame(player3, singlePlayerGame);

        Console.WriteLine("\n");

        gameAccount1.GetStats();
        gameAccount2.GetStats();
        gameAccount3.GetStats();
    }
}