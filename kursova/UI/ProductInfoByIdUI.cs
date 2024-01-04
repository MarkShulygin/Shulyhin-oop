using kursova.Database.Entity;
using kursova.Database.Service.Base;
using kursova.Database.Service;
using kursova.Database;
using kursova.UI.Base;

namespace kursova.UI;

public class ProductInfoById(DbContext context) : UserInterface
{
    IProductService productService = new ProductService(context);
    ProductEntity productEntity = new ProductEntity();

    public string Action()
    {
        Console.WriteLine("Enter product id:");
        var validId = int.TryParse(Console.ReadLine(), out int productid);
        if (!validId)
            return "Error - Can`t find product. Invalid ID.";
        var product = productService.ReadProductbyId(productid); ;
        string result = "";
        result += product.GetInfo();
        return result;
    }
    public string Show()
    {
        return $"Show Product info by Id";
    }
}
