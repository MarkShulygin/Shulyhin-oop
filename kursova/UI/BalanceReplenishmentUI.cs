using kursova.Database;
// using kursova.Database.Entity;
using kursova.Database.Service;
using kursova.Database.Service.Base;
using kursova.UI.Base;
using kursova.Users;


namespace kursova.UI
{
    public class BalanceReplenishment(DbContext context) : UserInterface
    {
        IUserService userService = new UserService(context);

        public string Action()
        {
            Console.WriteLine("Enter the amount of replenishment the balance");
            var validchanging = int.TryParse(Console.ReadLine(), out int changing);
            if (!validchanging)
                return "Error - Invalid Sum";
            User.CurrentUser.Balance = User.CurrentUser.Balance + changing;
            userService.UpdateUser(User.CurrentUser);
            return "Successfull balance replenishment";
        }
        public string Show()
        {
            return "Balance Replenishment";
        }
        
        
    }
}
