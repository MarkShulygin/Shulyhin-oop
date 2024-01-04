using kursova.Database.Entity;
using kursova.Database.Service.Base;
using kursova.Database.Service;
using kursova.Database;
using kursova.UI.Base;

namespace kursova.UI;

public class UserInfoById(DbContext context) : UserInterface
{
    IUserService userService = new UserService(context);
    UserEntity userEntity = new UserEntity();

    public string Action()
    {
        Console.WriteLine("Enter user id:");
        var validId = int.TryParse(Console.ReadLine(), out int userid);
        if (!validId)
            return "Error - Can`t find user. Invalid ID.";
        var user = userService.ReadAccountbyId(userid); ;
        string result = "";
        result += user.GetInfo();
        return result;
    }
    public string Show()
    {
        return $"Show User info by Id";
    }
}
