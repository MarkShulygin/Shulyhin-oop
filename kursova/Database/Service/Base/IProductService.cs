using kursova.Products;

namespace kursova.Database.Service.Base;

public interface IProductService
{
    public bool CreateProduct(StandartProduct product);
    public List<StandartProduct> ReadProducts();
    public StandartProduct ReadProductbyId(int searchId);
}
