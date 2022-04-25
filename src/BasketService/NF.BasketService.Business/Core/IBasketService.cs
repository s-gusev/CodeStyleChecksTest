namespace BasketService.Business.Core
{
    public interface IBasketService
    {
        Basket GetByKey(string key);
        void AddItemToBasket(string key, BasketItem basketItem);
        void RemoveItemFromBasket(string key, int itemId);
    }
}