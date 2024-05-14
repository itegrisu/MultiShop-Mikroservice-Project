namespace MultiShop.Basket.Dtos
{
    public class BasketItemDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public int Quantity { get; set; } // Üründen kaç adet aldığını söyler
        public decimal Price { get; set; }
    }
}
