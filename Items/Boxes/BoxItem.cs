using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace SlayerMod.Items.Boxes
{
    public class BoxItem
    {

        public int id;
        public int stack;
        int minStack;
        int maxStack;

        public BoxItem(int itemId, int min = 1, int max = 1)
        {
            id = itemId;
            minStack = min;
            maxStack = max;
            Random r = new Random();
            stack = r.Next(minStack, maxStack);
        }
    }
}
