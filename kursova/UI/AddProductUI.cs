using kursova.Database.Service.Base;
using kursova.Database.Service;
using kursova.Database;
using kursova.Products;
using kursova.UI.Base;

namespace kursova.UI;

public class AddProduct(DbContext context) : UserInterface
{
    IProductService productService = new ProductService(context);

    public string Action()
    {

        string productName;
        Console.WriteLine("Enter name for your new product:");
        productName = Console.ReadLine();

        Console.WriteLine("Enter future prodact cost:");
        var validCost = int.TryParse(Console.ReadLine(), out int productCost);
        if (!validCost)
            return "Error - Can`t create new prodact. Invalid Cost.";

        StandartProduct productEntity = new(productName, productCost);

        try
        {
            var result = productService.CreateProduct(productEntity);
            return "Product added successfuly";
        }
        catch (Exception e)
        {
            return $"Error - Can`t add product. {e.Message}";
        }
    }
    public string Show()
    {
        return "Add Product";
    }
}