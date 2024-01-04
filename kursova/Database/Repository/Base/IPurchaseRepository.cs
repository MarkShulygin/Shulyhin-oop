using kursova.Database.Entity;

namespace kursova.Database.Repository.Base
{
    public interface IPurchaseRepository
    {
        public void Create(PurchaseEntity purchase);
        public IEnumerable<PurchaseEntity> Read();
        public void Update(PurchaseEntity purchase);
        public void Delete(int Id);
        public IEnumerable<PurchaseEntity> ReadPurchesesByUserId(int searchId);
        public PurchaseEntity ReadPurchasebyId(int searchId);

    }
}
