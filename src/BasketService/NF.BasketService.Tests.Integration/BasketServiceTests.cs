using BasketService.Business.Core;
using BasketService.Business.Core.Configuration;
using BasketService.Business.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace BasketService.Tests.Integration
{
    [TestClass]
    public class BasketServiceTests
    {
        private static IBasketRepository _basketRepository;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _basketRepository = new BasketRepository(new BasketServiceConfiguration()
            {
                DbConnectionString = Constants.BasketDbConnectionString
            });
        }

        [TestMethod]
        public void AddItemToBasket()
        {
            var service = new Business.BLL.BasketService(_basketRepository);

            string uniqueBasketKey = Guid.NewGuid().ToString();
            service.AddItemToBasket(uniqueBasketKey, new BasketItem() {
                Name = "Test BasketItem Name",
                Quantity = 1,
                Price = 25m,
                ItemId = 1,
            });
        }
    }
}
