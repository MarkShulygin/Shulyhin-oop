using kursova.Database;
using kursova.UI;
using kursova.UI.Base;
using kursova.Users;

namespace kursova;

public class Main
{
    public List<UserInterface> LoginRegistration(DbContext context)
    {
        return
        [
                new LogInUser(context),
                new AddUserUI(context)    
        ];
    }
    public List<UserInterface> Setup(DbContext context)
    {
        return
        [
                new MakePurchase(context),
                new PurchaseInfo(context),
                new UsersInfo(context),
                new UserInfoById(context),
                new AddProduct(context),
                new ProductsInfo(context),
                new ProductInfoById(context),
                new BalanceReplenishment(context)
        ];
    }
}
public class Program
{
    static void Main()
    {
        DbContext context = new();
        var uis = new Main().LoginRegistration(context);
        while (true)
        {
            if(User.CurrentUser == null)
            {
                uis = new Main().LoginRegistration(context);
            }
            else
            {
                uis = new Main().Setup(context);
            }
            for (int i = 0; i < uis.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {uis[i].Show()}");
            }
            var key = Console.ReadLine();

            if (key == "quit")
                return;
            var isInt = int.TryParse(key, out int actionIndex);
            if (isInt == true && actionIndex <= uis.Count && actionIndex > 0)
                Console.WriteLine(uis[actionIndex - 1].Action());
            else
                Console.WriteLine($"Error - can`t parse {key}. Value has to be - [1:{uis.Count}].");
        }

    }
}