
namespace lab_work_3
{
    public class GameService : IGameService
    {
        private IGameRepository gameRepository;
        private IUserService userService;

        public GameService(DbContext dbcontext)
        {
            gameRepository = new GameRepository(dbcontext);
            userService = new UserService(dbcontext);
        }

        private AbstractGame Map(GameEntity game)
        {
            if(game.Type == GameType.WithoutDeductionPointsGame)
            {
                return new WithoutDeductionPointsGame()
                {
                    GameId = game.GameId,
                    FirstUser = userService.ReadAccountbyId(game.FirstUserId),
                    SecondUser = userService.ReadAccountbyId(game.SecondUserId),
                    Rating = game.Rating,
                    Result = game.Result
                };
            }
            else
            {
                return new StandartGame()
                {
                    GameId = game.GameId,
                    FirstUser = userService.ReadAccountbyId(game.FirstUserId),
                    SecondUser = userService.ReadAccountbyId(game.SecondUserId),
                    Rating = game.Rating,
                    Result = game.Result
                };
            }
        }

        public bool CreateGame(AbstractGame game, GameType gameType)
        {
            gameRepository.Create(
            new GameEntity
            {
                GameId = game.GameId,
                FirstUserId = game.FirstUser.Id,
                SecondUserId = game.SecondUser.Id,
                Rating = game.Rating,
                Result = game.Result,
                Type = gameType
            }
            );
            return true;
        }

        public List<AbstractGame> ReadGame()
        {
            List<AbstractGame> abstractGames = new List<AbstractGame>();
            foreach (GameEntity game in gameRepository.Read())
            {
                abstractGames.Add(Map(game));
            }
            return abstractGames;
        }

        public List<AbstractGame> ReadUsersGamesByUserId(int searchId)
        {
            List<AbstractGame> abstractGames = new List<AbstractGame>();
            foreach(GameEntity game in gameRepository.Read())
            {
                if(game.FirstUserId == searchId || game.SecondUserId == searchId)
                {
                    abstractGames.Add(Map(game));
                }
            }
            return abstractGames;
        }
    }
}

