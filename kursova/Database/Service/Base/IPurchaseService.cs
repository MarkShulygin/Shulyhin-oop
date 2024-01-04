using kursova.Purchases;

namespace kursova.Database.Service.Base
{
    public interface IPurchaseService
    {
        public bool CreatePurchase(Purchase purchase);
        public List<Purchase> ReadPurchases();
        public List<Purchase> ReadPurchasesByUserId(int searchId);
        public Purchase ReadPurchasebyId(int searchId);
    }
}
