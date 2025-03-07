using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hamaraBasket.Tests
{
    public class DomainFactory
    {
        public DomainFactory()
        {

        }

        public List<Item> CreateSingleItem(string name, int sellIn, int quality)
        {
            return new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
        }

        public void UpdateQuality(IList<Item> items)
        {
            HamaraBasket app = new HamaraBasket(items);
            app.UpdateQuality();
        }
    }
}
