using BasketService.Business.Core;
using BasketService.Business.Core.Configuration;

namespace BasketService.Business.DAL
{
    public class BasketRepository : BaseRepository, IBasketRepository
    {
        public BasketRepository(BasketServiceConfiguration configuration) : base(configuration)
        {
        }

        public Basket GetByKey(string basketKey)
        {
            using (var db = GetDbContext()) {
                var collection = db.GetCollection<Basket>();
                return collection.Query().Where(x => x.Key == basketKey).SingleOrDefault();
            }
        }

        public void CreateBasket(Basket basket)
        {
            using (var db = GetDbContext())
            {
                var collection = db.GetCollection<Basket>();
                // TODO: find better way to handle identity ids in LiteDB
                collection.Insert(basket.Key, basket);
            }
        }

        public void UpdateBasket(Basket basket)
        {
            using (var db = GetDbContext()) { 
                var collection = db.GetCollection<Basket>();
            collection.Update(basket.Key, basket);
            }
        }
    }
}
