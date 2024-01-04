
namespace lab_work_3
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IGameRepository gameRepository;

        public UserService(DbContext dbcontext)
        {
            userRepository = new UserRepository(dbcontext);
            gameRepository = new GameRepository(dbcontext);
        }

        private GameAccount Map(UserEntity user)
        {
            if (user.Type == UserType.DoublePointsGameAccount)
            {
                return new DoublePointsGameAccount(user.UserName)
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    CurrentRating = user.CurrentRating
                };
            }
            if (user.Type == UserType.DoubleDeductionPointsGameAccount)
            {
                return new DoubleDeductionPointsGameAccount(user.UserName)
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    CurrentRating = user.CurrentRating
                };
            }
            else
            {
                return new GameAccount(user.UserName)
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    CurrentRating = user.CurrentRating
                };
            }

        }

        public bool CreateAccount(GameAccount user, UserType userType)
        {
            userRepository.Create(
            new UserEntity
            {
                Id = user.Id,
                UserName = user.UserName,
                CurrentRating = user.CurrentRating,
                Type = userType
            }
            );
            return true;
        }

        public List<GameAccount> ReadAccounts()
        {
            List<GameAccount> gameAccounts = new List<GameAccount>();
            foreach (UserEntity user in userRepository.Read())
            {      
                gameAccounts.Add(Map(user));
            }
            return gameAccounts;
        }

        public GameAccount ReadAccountbyId(int searchId)
        {
            foreach (UserEntity user in userRepository.Read())
            {
                if(user.Id == searchId)
                {
                    return Map(user);
                }
            }
            return null;
        }
    }
}
