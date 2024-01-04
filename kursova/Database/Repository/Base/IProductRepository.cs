using kursova.Database.Entity;

namespace kursova.Database.Repository.Base;

public interface IProductRepository
{
    public void Create(ProductEntity product);
    public IEnumerable<ProductEntity> Read();
    public void Update(ProductEntity product);
    public void Delete(int Id);
    public ProductEntity ReadProductbyId(int searchId);
}
