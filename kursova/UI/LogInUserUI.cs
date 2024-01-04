using kursova.Database.Service.Base;
using kursova.Database.Service;
using kursova.Database;
using kursova.UI.Base;
using kursova.Users;

namespace kursova.UI
{
    public class LogInUser(DbContext context) : UserInterface
    {
        IUserService userService = new UserService(context);

        public string Action()
        {

            string login;
            do
            {
                Console.WriteLine("Enter user login");
                login = Console.ReadLine();
            }
            while (userService.ReadAccountbyLogin(login) == null);
            User.CurrentUser = userService.ReadAccountbyLogin(login);


            string password;
            do
            {
                Console.WriteLine("Enter password for this user");
                password = Console.ReadLine();
            }
            while (User.CurrentUser.Password != password);
            return "User log in successfully";
        }
        public string Show()
        {
            return "Log in user";
        }
    }
}
