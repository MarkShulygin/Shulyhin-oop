using kursova.Database.Entity;
using kursova.Database.Repository.Base;
using kursova.Database.Repository;
using kursova.Database.Service.Base;
using kursova.Products;

namespace kursova.Database.Service;

public class ProductService(DbContext dbcontext) : IProductService
{
    private IProductRepository productRepository = new ProductRepository(dbcontext);

    private StandartProduct Map(ProductEntity product)
    {
        return new StandartProduct(product.Id, product.Name, product.Cost);
    }

    public bool CreateProduct(StandartProduct product)
    {
        productRepository.Create(
        new ProductEntity
        {
            Id = product.Id,
            Name = product.Name,
            Cost = product.Cost
        }
        );
        return true;
    }

    public List<StandartProduct> ReadProducts()
    {
        List<StandartProduct> products = new List<StandartProduct>();
        foreach (ProductEntity product in productRepository.Read())
        {
            products.Add(Map(product));
        }
        return products;
    }

    public StandartProduct ReadProductbyId(int searchId)
    {
        return Map(productRepository.ReadProductbyId(searchId));
    }
}
