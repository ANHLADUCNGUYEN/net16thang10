namespace Bai03_SupermarketMDI
{
    public class Product
    {
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal TotalValue => Price * Quantity;

        public Product() { }

        public Product(string id, string name, string category, decimal price, int quantity)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }
    }
}
