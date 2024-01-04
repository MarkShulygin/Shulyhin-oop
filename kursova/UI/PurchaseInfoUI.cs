using kursova.Database.Service.Base;
using kursova.Database.Service;
using kursova.Database;
using kursova.UI.Base;
using kursova.Users;

namespace kursova.UI
{
    public class PurchaseInfo(DbContext context) : UserInterface
    {
        IPurchaseService purchaseService = new PurchaseService(context);
        int userId = User.CurrentUser.UserId;

        public string Action()
        {
            var purchases = purchaseService.ReadPurchasesByUserId(userId);
            string result = "";
            foreach (var purchase in purchases)
            {
                result += purchase.GetInfo() + "\n";
            }
            return result;
        }
        public string Show()
        {
            return "Show all User Purchases";
        }
    }
}
