
namespace lab_work_3
{
    public class AddGameUI : IUserInterface
    {
        IGameService gameService;
        IUserService userService;
        public AddGameUI(DbContext context)
        {
            gameService = new GameService(context);
            userService = new UserService(context);
        }
        public string Action()
        {
            //gametype
            AbstractGame gameEntity;
            Console.WriteLine("Choose type of Game:\r\n\t\tStandart game[0],\r\n\t\tWithout Deduction Points Game[1]");
            GameType gameTypeEnum;
            string gametype = Console.ReadLine();
            if (gametype[0] != '0' && gametype[0] != '1' && gametype[0] != '2')
                return "Unknown game type.";
            if (gametype[0] == '1')
            {
                gameEntity = new WithoutDeductionPointsGame();
                gameTypeEnum = GameType.WithoutDeductionPointsGame;
            }
            else
            {
                gameEntity = new StandartGame();
                gameTypeEnum = GameType.StandartGame;
            }

            //firstid
            Console.WriteLine("Enter User id:");
            int firstuserid;
            var firstvalidId = int.TryParse(Console.ReadLine(), out firstuserid);
            if (!firstvalidId)
                return "Can`t find user. Invalid ID.";
            gameEntity.FirstUser = userService.ReadAccountbyId(firstuserid);

            //secondid
            Console.WriteLine("Enter User id:");
            int seconduserid;
            var secondvalidId = int.TryParse(Console.ReadLine(), out seconduserid);
            if (!secondvalidId)
                return "Can`t find user. Invalid ID.";
            gameEntity.SecondUser = userService.ReadAccountbyId(seconduserid);

            //rating
            Console.WriteLine("Enter Rating Users are playing for:");
            int rating;
            var validrating = int.TryParse(Console.ReadLine(), out rating);
            if (!validrating)
                return "Invalid Rating.";
            gameEntity.Rating = rating;

            //result
            Console.WriteLine("Enter Result of the Game ");
            GameResult gameResult;
            string result = Console.ReadLine();
            if (result[0] != '0' && result[0] != '1')
                return "Invalid Result.";
            if (result[0] == '1')
            {
                gameEntity.Result = GameResult.Win;
            }
            else
            {
                gameEntity.Result = GameResult.Lose;
            }

            //gameid
            Console.WriteLine("Enter Game id:");
            int gameid;
            var validId = int.TryParse(Console.ReadLine(), out gameid);
            if (!validId)
                return "Invalid ID.";
            gameEntity.GameId = gameid;
            try
            {
                var resultAddGame = gameService.CreateGame(gameEntity, gameTypeEnum);
                return "Game added";
            }
            catch (Exception e)
            {
                return $"Can`t add game. {e.Message}";
            }

        }
        public string Show()
        {
                return "Add Game.";
        }
    }
       
}
