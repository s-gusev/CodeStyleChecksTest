using BasketService.Business.Core.Configuration;
using LiteDB;

namespace BasketService.Business.DAL
{
    public class BaseRepository
    {
        private readonly BasketServiceConfiguration _configuration;

        public BaseRepository(BasketServiceConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected LiteDatabase GetDbContext()
        {
            return new LiteDatabase(_configuration.DbConnectionString);
        }
    }
}