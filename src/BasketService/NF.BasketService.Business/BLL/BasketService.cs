using System;
using System.Collections.Generic;
using System.Linq;
using BasketService.Business.Core;

namespace BasketService.Business.BLL
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public Basket GetByKey(string basketKey)
        {
            return _basketRepository.GetByKey(basketKey);
        }

        public void AddItemToBasket(string basketKey, BasketItem basketItem)
        {
            var basket = GetByKey(basketKey);
            if (basket != null)
            {
                var existingItem = basket.BasketItems.SingleOrDefault(i => i.ItemId == basketItem.ItemId);
                if (existingItem != null)
                {
                    existingItem.Quantity += basketItem.Quantity;
                }
                else
                {
                    basket.BasketItems.Add(basketItem);
                }

                _basketRepository.UpdateBasket(basket);
            }
            else
            {
                _basketRepository.CreateBasket(new Basket
                {
                    Key = basketKey,
                    BasketItems = new List<BasketItem> { basketItem }
                });
            }
        }

        public void RemoveItemFromBasket(string basketKey, int itemId)
        {
            var basket = GetByKey(basketKey);
            var existingItem = basket?.BasketItems.SingleOrDefault(i => i.ItemId == itemId);
            if (existingItem == null)
                return;

            existingItem.Quantity -= 1;
            if (existingItem.Quantity <= 0)
            {
                basket.BasketItems.Remove(existingItem);
            }
            _basketRepository.UpdateBasket(basket);
        }
    }
}
