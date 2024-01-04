using kursova.Database.Entity;

namespace kursova.Database;

public class DbContext
{
    public List<UserEntity> Users { get; set; }
    public List<ProductEntity> Products { get; set; }
    public List<PurchaseEntity> Purchases { get; set; }
    public DbContext()
    { 
        Users =
        [
            new() {Id = 1, UserName = "Mark", Login = "kram", Password = "qwertyui"},
            new() {Id = 2, UserName = "Vadim", Login = "c1v1k", Password = "qwertyui"},
            new() {Id = 3, UserName = "Ivan", Login = "lark", Password = "qwertyui"}
        ];
        Products =
        [
            new() {Id = 1, Name = "Uncharted 1", Cost = 300},
            new() {Id = 2, Name = "Uncharted 2", Cost = 400},
            new() {Id = 3, Name = "Uncharted 3", Cost = 500},
            new() {Id = 4, Name = "Uncharted 4", Cost = 600},
        ];
        Purchases = [];
    }
}
