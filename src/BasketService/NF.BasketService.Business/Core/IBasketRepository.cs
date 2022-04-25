namespace BasketService.Business.Core
{
    public interface IBasketRepository
    {
        Basket GetByKey(string basketKey);
        void CreateBasket(Basket basket);
        void UpdateBasket(Basket basket);
    }
}