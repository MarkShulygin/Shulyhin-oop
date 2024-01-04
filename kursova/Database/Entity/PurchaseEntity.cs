namespace kursova.Database.Entity
{
    public class PurchaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int CountOfProducts { get; set; }
    }
}
