using kursova.Database.Entity;
using kursova.Database.Repository.Base;
using kursova.Database.Repository;
using kursova.Database.Service.Base;
using kursova.Users;

namespace kursova.Database.Service;

public class UserService(DbContext dbcontext) : IUserService
{
    private IUserRepository userRepository = new UserRepository(dbcontext);

    private User Map(UserEntity user)
    {
        if(user == null)
        {
            return null;
        }
        return new User(user.Id, user.UserName, user.Balance, user.Login, user.Password);
    }

    private UserEntity Map(User user)
    {
        if (user == null)
        {
            return null;
        }
        return new UserEntity()
        {
            Id = user.UserId,
            UserName = user.UserName,
            Balance = user.Balance,
            Login = user.Login,
            Password = user.Password
        };
    }

    public bool UserRegistration(User user)
    {
        userRepository.Create(
        new UserEntity
        {
            Id = user.UserId,
            UserName = user.UserName,
            Balance = user.Balance,
            Login = user.Login,
            Password = user.Password
        }
        );
        return true;
    }

    public List<User> ReadAccounts()
    {
        List<User> users = new List<User>();
        foreach (UserEntity user in userRepository.Read())
        {
            users.Add(Map(user));
        }
        return users;
    }

    public User ReadAccountbyId(int searchId)
    {
        return Map(userRepository.ReadAccountbyId(searchId));
    }

    public User ReadAccountbyLogin(string searchLogin)
    {
        return Map(userRepository.ReadAccountbyLogin(searchLogin));
    }

    public User ReadAccountbyPassword(string searchPassword)
    {
        return Map(userRepository.ReadAccountbyPassword(searchPassword));
    }

    public void UpdateUser(User user)
    {
        userRepository.Update(Map(user));
    }
}
