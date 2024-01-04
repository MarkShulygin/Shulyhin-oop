using kursova.Database.Repository.Base;
using kursova.Database.Repository;
using kursova.Database.Service.Base;
using kursova.Database.Entity;
using kursova.Purchases;


namespace kursova.Database.Service
{
    public class PurchaseService(DbContext dbcontext) : IPurchaseService
    {
        private IUserService userService = new UserService(dbcontext);
        private IPurchaseRepository purchaseRepository = new PurchaseRepository(dbcontext);
        private IProductService productService = new ProductService(dbcontext);

        private Purchase Map(PurchaseEntity purchase)
        {
            if (purchase == null)
            {
                return null;
            }
            var user = userService.ReadAccountbyId(purchase.UserId);
            var product = productService.ReadProductbyId(purchase.ProductId);
            return new Purchase(purchase.Id, user, product, purchase.CountOfProducts);

        }
        public bool CreatePurchase(Purchase purchase)
        {
            purchaseRepository.Create(
            new PurchaseEntity
            {
                Id = purchase.Id,
                UserId = purchase.User.UserId,
                ProductId = purchase.Product.Id,
                CountOfProducts = purchase.CountOfProducts
            }
            );
            return true;
        }
        public List<Purchase> ReadPurchasesByUserId(int searchId)
        {
            List<Purchase> purchases = new List<Purchase>();
            foreach(PurchaseEntity purchase in purchaseRepository.ReadPurchesesByUserId(searchId))
            {
                purchases.Add(Map(purchase));
            }
            return purchases;
        }

        public List<Purchase> ReadPurchases()
        {
            List<Purchase> purchases = new List<Purchase>();
            foreach (PurchaseEntity purchase in purchaseRepository.Read())
            {
                purchases.Add(Map(purchase));
            }
            return purchases;
        }
        public Purchase ReadPurchasebyId(int searchId)
        {
            return Map(purchaseRepository.ReadPurchasebyId(searchId));
        }
    }
}
