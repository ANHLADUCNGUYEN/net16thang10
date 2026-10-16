namespace InventoryManager
{
    public class Product
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; } = "";   // chỉ lưu đường dẫn, không lưu ảnh
        public decimal Total => Quantity * Price;
    }
}