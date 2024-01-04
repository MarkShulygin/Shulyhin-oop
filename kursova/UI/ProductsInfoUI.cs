using kursova.Database.Service.Base;
using kursova.Database.Service;
using kursova.Database;
using kursova.UI.Base;

namespace kursova.UI;

public class ProductsInfo(DbContext context) : UserInterface
{
    IProductService productService = new ProductService(context);

    public string Action()
    {
        var products = productService.ReadProducts();
        string result = "";
        foreach (var productEntity in products)
        {
            result += productEntity.GetInfo() + "\n";
        }
        return result;
    }
    public string Show()
    {
        return "Show all products";
    }
}
