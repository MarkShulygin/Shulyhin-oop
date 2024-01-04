using kursova.Database.Service.Base;
using kursova.Database.Service;
using kursova.Database;
using kursova.UI.Base;

namespace kursova.UI;

public class UsersInfo(DbContext context) : UserInterface
{
    IUserService userService = new UserService(context);

    public string Action()
    {
        var users = userService.ReadAccounts();
        string result = "";
        foreach (var userEntity in users)
        {
            result += userEntity.GetInfo() + "\n";
        }
        return result;
    }
    public string Show()
    {
        return "Show all users";
    }
}
