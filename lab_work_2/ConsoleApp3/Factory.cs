public class GameFactory
{
    public BaseGame CreateGame(string Type) //Метод для створення гри
    {
        return Type switch
        {
            "Standard" => new StandardGame(),
            "Training" => new TrainingGame(),
            "SinglePlayer" => new SinglePlayerGame(),
            _ => throw new ArgumentException("Invalid game type"),
        };
    }
}