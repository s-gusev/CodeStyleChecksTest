namespace BasketService.Business.Core
{
    public class BasketItem
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}