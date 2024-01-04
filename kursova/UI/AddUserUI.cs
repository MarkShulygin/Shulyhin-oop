using kursova.Database.Service.Base;
using kursova.Database.Service;
using kursova.Database;
using kursova.Users;
using kursova.UI.Base;

namespace kursova.UI;

public class AddUserUI(DbContext context) : UserInterface
{
    IUserService userService = new UserService(context);

    public string Action()
    {
        //username
        string userName;
        Console.WriteLine("Enter new user name:");
        userName = Console.ReadLine();
        //login
        string login;
        do
        {
            Console.WriteLine("Enter new user login, for example MarkosSH");
            login = Console.ReadLine();
        }
        while (userService.ReadAccountbyLogin(login) != null);
        //password
        string password;
        Console.WriteLine("Enter new user password");
        password = Console.ReadLine();

        User userEntity = new(userName, login, password);

        try
        {
            var result = userService.UserRegistration(userEntity);
            return "User added";
        }
        catch (Exception e)
        {
            return $"Error - Can`t add new user. {e.Message}";
        }
    }
    public string Show()
    {
        return "Add User";
    }
}
