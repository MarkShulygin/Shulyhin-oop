
namespace lab_work_3
{
    public class DbContext
    {
        public List<UserEntity> Users { get; set; }
        public List<GameEntity> Games { get; set; }

        public DbContext() {
            Users = new List<UserEntity>
            {
                new UserEntity {Id = 1, UserName = "Mark", CurrentRating = 1700, Type = UserType.GameAccount},
                new UserEntity {Id = 2, UserName = "Ivan", CurrentRating = 1340, Type = UserType.GameAccount},
                new UserEntity {Id = 3, UserName = "Arseniy", CurrentRating = 2490, Type = UserType.GameAccount},
                new UserEntity {Id = 4, UserName = "Vadim", CurrentRating = 700, Type = UserType.GameAccount}
            };
            Games = new List<GameEntity>
            {
                new GameEntity{FirstUserId = 1, SecondUserId = 2, Rating = 1000, Result = GameResult.Win, GameId = 1, Type = GameType.StandartGame},
                new GameEntity{FirstUserId = 3, SecondUserId = 4, Rating = 100, Result = GameResult.Win, GameId = 2, Type = GameType.StandartGame},
                new GameEntity{FirstUserId = 1, SecondUserId = 2, Rating = 1000, Result = GameResult.Lose, GameId = 3, Type = GameType.StandartGame},
            };
        }
        
    }
}
