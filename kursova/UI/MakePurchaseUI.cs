using kursova.Database;
using kursova.Database.Service;
using kursova.Database.Service.Base;
using kursova.Purchases;
using kursova.UI.Base;
using kursova.Users;

namespace kursova.UI
{
    public class MakePurchase(DbContext context) : UserInterface
    {
        IPurchaseService purchaseService = new PurchaseService(context);
        IProductService productService = new ProductService(context);
        IUserService userService = new UserService(context);

        public string Action()
        {
            int productId;
            do
            {
                Console.WriteLine("Enter product id");
                var validId = int.TryParse(Console.ReadLine(), out productId);
                if (!validId)
                    return "Can`t find Product. Error - Invalid id.";
            } while (productService.ReadProductbyId(productId) == null);

            User user = User.CurrentUser;
            var product = productService.ReadProductbyId(productId);

            Console.WriteLine("Enter amount of products");
            var validCountId = int.TryParse(Console.ReadLine(), out int countOfProducts);
            if(!validCountId)
                return "Error - Invalid amount.";
            if(User.CurrentUser.Balance < product.Cost * countOfProducts)
            {
                return $"Error - Can`t make purchase. Fill up Balance,";
            }
            Purchase purchase = new(user, product, countOfProducts);
            try
            {
                var result = purchaseService.CreatePurchase(purchase);
                User.CurrentUser.Balance = User.CurrentUser.Balance - product.Cost * countOfProducts;
                userService.UpdateUser(User.CurrentUser);
                return "Purchase made!";
            }
            catch (Exception e)
            {
                return $"Can`t make purchase. {e.Message}";
            }
        }
        public string Show()
        {
            return "Make Purchase";
        }
    }
}
