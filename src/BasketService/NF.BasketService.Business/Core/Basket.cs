using System.Collections.Generic;

namespace BasketService.Business.Core
{
    public class Basket
    {
        public string Key { get; set; }

        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
		
		
    }
}
