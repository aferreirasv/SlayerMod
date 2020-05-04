using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlayerMod.NPCs
{
    public class ShopItem
    {
        public int id;
        public int price;
        private bool condition;

        public ShopItem(int itemId, int itemPrice, bool itemCondition = true)
        {
            id = itemId;
            price = itemPrice;
            condition = itemCondition;
        }
        public bool Available()
        {
            return condition;
        }        
    }


}
